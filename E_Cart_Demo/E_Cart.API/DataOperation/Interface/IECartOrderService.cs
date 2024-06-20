﻿using ECart.API.Data.Models;

namespace ECart.API.DataOperation.Interface;

public interface IECartOrderService
{
    public Task<ApiResult> CreateOrder(ECartOrderModel model);
    public Task<ApiResult<List<ECartOrderModel>>> GetOrders(int userId);
    public Task<ApiResult<List<ECartOrderItemModel>>> GetOrderDetails(int id);
}
