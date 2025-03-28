using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AbstractRepositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsByProductId(int? productId);
    }
}
