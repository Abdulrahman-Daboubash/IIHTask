using Application.Service.OrderDetailServices.OrderDetailDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.OrderDetailService.OrderDetailService
{
    public interface IOrderDetailService
    {
        public IQueryable<OrderDetailDto> GetOrderDetails();
        public OrderDetail GetOrderDetail(Guid id);
        public List<OrderDetail> GetDetailsByOrderId(Guid orderId);
        public void UpdateOrderDetail(Guid id, OrderDetail orderDetail);
        public void DeleteOrderDetail(Guid id);
    }
}
