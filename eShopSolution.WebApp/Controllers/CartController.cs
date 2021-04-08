using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.ApiIntegration;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Order;
using eShopSolution.ViewModels.Sales;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShopSolution.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IOrderApiClient _orderApiClient;
        public CartController(IProductApiClient productApiClient, IOrderApiClient orderApiClient)
        {
            _productApiClient = productApiClient;
            _orderApiClient = orderApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            ViewBag.User = HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            if (ViewBag.User == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(GetCheckoutViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel request)
        {
            var model = GetCheckoutViewModel();
            var orderDetails = new List<OrderDetailVm>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderDetailVm()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            var checkoutRequest = new OrderVm()
            {
                ShipAddress = request.CheckoutModel.Address,
                ShipEmail = request.CheckoutModel.Email,
                ShipName = request.CheckoutModel.Name,
                ShipPhoneNumber = request.CheckoutModel.PhoneNumber,
                UserId = Guid.Parse("A252F2A1-4D6F-4F6C-CB65-08D8F920AFD2")
            };
            //TODO: Add to API

            var result = await _orderApiClient.Add(checkoutRequest);

            TempData["SuccessMsg"] = "Order puschased successful";
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            session = null;
            //session = null;
            return View(model);
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            return Ok(currentCart);
        }

        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetById(id, languageId);
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
                if (currentCart.Exists(x => x.ProductId == id))
                {
                    foreach (var item in currentCart)
                    {
                        if (item.ProductId == id)
                        {
                            item.Quantity += 1;
                        }
                    }
                }
                else
                {
                    var cartItem = new CartItemViewModel()
                    {
                        ProductId = id,
                        Description = product.Description,
                        Image = product.ThumbnailImage,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = 1
                    };

                    currentCart.Add(cartItem);
                }
            }
            else
            {
                var item = new CartItemViewModel();
                item.ProductId = id;
                item.Description = product.Description;
                item.Name = product.Name;
                item.Price = product.Price;
                item.Quantity = 1;
                currentCart.Add(item);
            }

            //var product = await _productApiClient.GetById(id, languageId);

            //var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            //List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            //if (session != null)
            //    currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            //int quantity = 1;
            //if (currentCart.Any(x => x.ProductId == id))
            //{
            //    quantity = currentCart.First(x => x.ProductId == id).Quantity + 1;
            //}
            //else
            //{
            //    var cartItem = new CartItemViewModel()
            //    {
            //        ProductId = id,
            //        Description = product.Description,
            //        Image = product.ThumbnailImage,
            //        Name = product.Name,
            //        Price = product.Price,
            //        Quantity = quantity
            //    };

            //    currentCart.Add(cartItem);
            //}

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            foreach (var item in currentCart)
            {
                if (item.ProductId == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        private CheckoutViewModel GetCheckoutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            //session = null;
            var checkoutVm = new CheckoutViewModel()
            {
                CartItems = currentCart,
                CheckoutModel = new CheckoutRequest()
            };
            return checkoutVm;
        }
    }
}