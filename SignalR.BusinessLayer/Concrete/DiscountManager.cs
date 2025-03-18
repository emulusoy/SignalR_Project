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
    public class DiscountManager:IDiscountService
    {
        private readonly IDiscountDal discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            this.discountDal = discountDal;
        }

        public void TAdd(Discount entity)
        {
            discountDal.Add(entity);
        }

        public void TDelete(Discount entity)
        {
            discountDal.Delete(entity);
        }

        public Discount TGetById(int id)
        {
            return discountDal.GetById(id);
        }

        public List<Discount> TGetListAll()
        {
            return discountDal.GetListAll();
        }

        public void TUpdate(Discount entity)
        {
            discountDal.Update(entity);
        }
    }
}
