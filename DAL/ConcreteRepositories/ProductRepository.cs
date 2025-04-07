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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
           .Include(p => p.Category) 
           .Include(p => p.Brand)    
           .ToList();
        }

        public List<Product> SearchProducts(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<Product>(); 
            }

           
            return _context.Products
                .Include(p => p.Category) 
                .Include(p => p.Brand)    
                .Where(p => p.Name.Contains(query) ||
                             (p.Brand != null && p.Brand.Name.Contains(query)) ||
                             (p.Category != null && p.Category.Name.Contains(query)))
                .ToList();
        }
    }
}
