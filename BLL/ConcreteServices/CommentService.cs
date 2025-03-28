using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.AbstractRepositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class CommentService : ICommentService
    {
        private readonly IGenericRepository<Comment> _genericRepository;
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IGenericRepository<Comment> genericRepository,IMapper mapper,ICommentRepository commentRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }


        public void AddComment(CommentDto commentDto)
        {
            _genericRepository.Add(_mapper.Map<Comment>(commentDto));

        }

        public void DeleteComment(int commentId)
        {
            _genericRepository.DeleteById(commentId);
        }

        public List<CommentDto> GetCommentsByProductId(int productId)
        {
          var comments = _commentRepository.GetCommentsByProductId(productId);
            return _mapper.Map<List<CommentDto>>(comments);
        }

      
    }
}
