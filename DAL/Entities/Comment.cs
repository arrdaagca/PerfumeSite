using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment : BaseClass
    {


        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product   Product { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;



    }
}
