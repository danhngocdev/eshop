using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.ApiIntegration;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
        public OrderController(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
