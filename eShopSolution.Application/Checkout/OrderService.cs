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
    public class OrderService : IOrderService
    {
        private readonly EShopDbContext _context;

        public OrderService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Add(OrderVm request)
        {
            var order = new Order()
            {
                ShipName = request.ShipName,
                ShipAddress = request.ShipAddress,
                ShipPhoneNumber = request.ShipPhoneNumber,
                Status = Data.Enums.OrderStatus.InProgress,
                ShipEmail = request.ShipName,
                UserId = request.UserId,
                OrderDate = DateTime.Now,
             

            };
            var result =  _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();

        }

        public Task<ApiResult<bool>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<OrderVm>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Update(Guid id, OrderVm request)
        {
            throw new NotImplementedException();
        }
    }
}
