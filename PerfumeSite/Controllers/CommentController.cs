using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.CommentViewModels;

namespace PerfumeSite.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService,IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComments(int productId)
        {

            var comments = _commentService.GetCommentsByProductId(productId);

            var commentViewModels = _mapper.Map<List<CommentViewModel>>(comments);
            return View(commentViewModels);


        }
        [HttpPost]
        public IActionResult AddComment(CommentViewModel commentViewModel)
        {
            
            if (commentViewModel.UserId == 0 || commentViewModel.ProductId == 0 || string.IsNullOrEmpty(commentViewModel.CommentText))
            {
               
                
                return RedirectToAction("ProductDetails", "Product", new { id = commentViewModel.ProductId });
            }

            
            var commentDto = _mapper.Map<CommentDto>(commentViewModel);
            _commentService.AddComment(commentDto); 

            
            return RedirectToAction("ProductDetails", "Product", new { id = commentViewModel.ProductId });
        }


    }
}
