using eShopSolution.Data.Entities;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Checkout
{
    interface IOrderDetailService
    {
        Task<ApiResult<bool>> Add(OrderVm request, List<OrderDetail> orderDetails);
    }
}
