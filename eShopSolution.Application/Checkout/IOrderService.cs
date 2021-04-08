using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Checkout
{
  public  interface IOrderService
    {
        Task<ApiResult<bool>> Update(Guid id, OrderVm request);

        Task<ApiResult<bool>> Add(OrderVm request);

        //Task<ApiResult<PagedResult<OrderVm>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<OrderVm>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);
    }
}
