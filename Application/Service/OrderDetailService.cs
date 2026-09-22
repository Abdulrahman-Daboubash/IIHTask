using Application.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Application.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        public OrderDetailService(IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public void DeleteOrderDetail(int id)
        {
            var detail = _orderDetailRepository.GetById(id);
            if (detail != null)
            {
                _orderDetailRepository.Delete(detail);
            }
        }

        public OrderDetail GetOrderDetail(int id)
        {
            var detail = _orderDetailRepository.GetById(id);
            return detail;
        }

        public List<OrderDetail> GetOrderDetails()
        {
            var details = _orderDetailRepository.GetAll();
            return details;
        }

        public List<OrderDetail> GetDetailsByOrderId(int orderId)
        {
            var details = _orderDetailRepository.GetAll()
                .Where(od => od.OrderId == orderId)
                .ToList();

            return details;
        }
        public void UpdateOrderDetail(int id, OrderDetail orderDetail)
        {
            var x = _orderDetailRepository.GetById(id);
            if (x != null)
            {
                x.OrderId = orderDetail.OrderId;
                x.ProductId = orderDetail.ProductId;
                x.Quantity = orderDetail.Quantity;
                x.Price = orderDetail.Price;
                
                _orderDetailRepository.Update(x);
            }
        }
    }
}
