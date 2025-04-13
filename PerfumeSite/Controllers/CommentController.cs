using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using BLL.ConcreteServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.CommentViewModels;

namespace PerfumeSite.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public CommentController(ICommentService commentService,IMapper mapper,IOrderService orderService)
        {
            _commentService = commentService;
            _mapper = mapper;
            _orderService = orderService;
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
            var userId = HttpContext.Session.GetInt32("Id");

            var order = _orderService.GetOrdersByUserId(userId).FirstOrDefault(o => o.ProductId == commentViewModel.ProductId);
            if (order == null)
            {
                TempData["ErrorMessage"] = "Sadece satın aldığınız ürünlere yorum yazabilirsiniz.";
                return RedirectToAction("ProductDetails", "Product", new { id = commentViewModel.ProductId });
            }


            if (commentViewModel.UserId == 0 || commentViewModel.ProductId == 0 || string.IsNullOrEmpty(commentViewModel.CommentText))
            {
               
                
                return RedirectToAction("ProductDetails", "Product", new { id = commentViewModel.ProductId });
            }

            
            var comment = _mapper.Map<CommentDto>(commentViewModel);
            _commentService.AddComment(comment); 

            
            return RedirectToAction("ProductDetails", "Product", new { id = commentViewModel.ProductId });
        }


    }
}
