using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class CommentDto : BaseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
