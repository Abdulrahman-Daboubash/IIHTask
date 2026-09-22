using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public interface IOrderDetailService
    {
        public List<OrderDetail> GetOrderDetails();
        public OrderDetail GetOrderDetail(int id);
        public List<OrderDetail> GetDetailsByOrderId(int orderId);
        public void UpdateOrderDetail(int id, OrderDetail orderDetail);
        public void DeleteOrderDetail(int id);
    }
}
