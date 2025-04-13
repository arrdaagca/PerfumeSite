using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class ProductRatingDto : BaseDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Score { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
