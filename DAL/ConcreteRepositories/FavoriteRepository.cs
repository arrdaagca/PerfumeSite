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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Favorite> GetFavoritesByUserId(int? userId)
        {
            var favorites = _context.Favorites.Where(a => a.UserId == userId).ToList();
            return favorites;

        }

        public bool IsFavorite(int userId, int productId)
        {
            return _context.Favorites.Any(f => f.UserId == userId && f.ProductId == productId);
        }
    }
}
