using DAL.AbstractRepositories;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConcreteRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrdersByUserId(int? userId)
        {
            var orders = _context.Orders.Where(a => a.UserId == userId).ToList();
            return orders;

        }
    }
}
