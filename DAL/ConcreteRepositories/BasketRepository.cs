using DAL.AbstractRepositories;
using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConcreteRepositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly AppDbContext _context;

        public BasketRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Basket> GetBasketByUserId(int? userId)
        {
            var basket = _context.Baskets.Where(a => a.UserId == userId).ToList();
            return basket;
        }

        public bool IsBasket(int userId, int productId)
        {
            return _context.Baskets.Any(f => f.UserId == userId && f.ProductId == productId);
        }
    }
}
