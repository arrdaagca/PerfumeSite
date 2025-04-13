using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductRating : BaseClass
    {


        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Score { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Product Product { get; set; }
    }
}