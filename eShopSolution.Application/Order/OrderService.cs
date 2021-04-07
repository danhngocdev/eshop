using eShopSolution.Data.EF;
using eShopSolution.Data.Enums;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.Application.Order;

namespace eShopSolution.Application.Order
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
            //try
            //{
            //    var order = new Order()
            //    {
            //        ShipAddress = request.ShipAddress,
            //        ShipEmail = request.ShipEmail,
            //        ShipName = request.ShipName,
            //        Status = (int)OrderStatus.InProgress
            //    };

            //    _context.Orders.Add(order);
            //    await _context.SaveChangesAsync();
            //    return product.Id;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException();
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