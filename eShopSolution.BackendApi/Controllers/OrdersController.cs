using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Checkout;
using eShopSolution.Data.Entities;
using eShopSolution.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpPost]

        public async Task<IActionResult> Register([FromBody] OrderVm request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _orderService.Add(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
