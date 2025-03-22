using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal

    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context=new SignalRContext();
            var values=context.Products.Include(x=>x.Category).ToList();    
            return values;
        }

        public int ProductCount()
        {
            using var context=new SignalRContext(); 
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            var context = new SignalRContext();
            return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Count();
            
        }

        public int ProductCountByCategoryNameHamburger()
        {
            var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Drink").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            var context = new SignalRContext();
            return context.Products.Where(x=>x.ProductPrice==(context.Products.Max(y=>y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            var context = new SignalRContext();
            return context.Products.Where(x => x.ProductPrice == (context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Average(x => x.ProductPrice);
        }

        public decimal ProductPriceByHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Category.CategoryName == "Hamburger").Select(y => y.ProductPrice).Average();
        }
    }
}
