using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Checkout
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly EShopDbContext _context;

        public OrderDetailService(EShopDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<bool>> Add(OrderVm request, List<OrderDetail> orderDetails)
        {
            return new ApiSuccessResult<bool>();
        }
    }
}
