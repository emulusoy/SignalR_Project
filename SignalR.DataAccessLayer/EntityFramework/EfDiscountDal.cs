using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeStatusFalse(int id)
        {
           var context =new SignalRContext();
            var value =context.Discounts.Find(id);
            value.Status = false;
            context.SaveChanges();

        }
        public void ChangeStatusTrue(int id)
        {
            var context = new SignalRContext();
            var value = context.Discounts.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public List<Discount> GetListByStatusTrue()
        {
            var context = new SignalRContext();
            var value = context.Discounts.Where(x=>x.Status==true).ToList();
            return value;
        }
    }
}
