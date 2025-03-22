using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager:IOrderService
    {
        private readonly IOrderDal _orderDall;

        public OrderManager(IOrderDal orderDall)
        {
            _orderDall = orderDall;
        }

        public int TActiveOrderCount()
        {
            return _orderDall.TotalOrderCount();
        }

        public void TAdd(Order entity)
        {
             _orderDall.Add(entity);
        }

        public void TDelete(Order entity)
        {
             _orderDall.Delete(entity);   
        }

        public Order TGetById(int id)
        {
            return _orderDall.GetById(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDall.GetListAll();
        }

        public decimal TLastOrderPrice()
        {
            return _orderDall.LastOrderPrice();
        }

        public int TTotalOrderCount()
        {
            return _orderDall.TotalOrderCount();   
        }

        public void TUpdate(Order entity)
        {
            _orderDall.Update(entity);
        }
    }
}
