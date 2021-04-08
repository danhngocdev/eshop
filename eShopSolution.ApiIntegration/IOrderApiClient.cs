using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<ApiResult<bool>> Add(OrderVm registerRequest);
    }
}