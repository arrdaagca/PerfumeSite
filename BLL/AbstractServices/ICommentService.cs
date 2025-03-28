using BLL.AllDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface ICommentService
    {


        void AddComment(CommentDto commentDto);
        List<CommentDto> GetCommentsByProductId(int productId);
        void DeleteComment(int commentId);



    }
}
