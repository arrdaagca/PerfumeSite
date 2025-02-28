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
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly AppDbContext _context;

        public CreditCardRepository(AppDbContext context )
        {
            _context = context;
        }

        public List<CreditCard> GetCreditCardByUserId(int? userId)
        {
            var userCreditCards = new List<CreditCard>();   


            var creditCards = _context.CreditCards.Where(c => c.UserId == userId).ToList();

            return creditCards;

        }
    }
}
