using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;

namespace PerfumeSite.Controllers
{
    public class ProductRatingController : Controller
    {
        private readonly IProductRatingService _productRatingService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public ProductRatingController(IProductRatingService productRatingService,IMapper mapper,IOrderService orderService)
        {
            _productRatingService = productRatingService;
            _mapper = mapper;
            _orderService = orderService;
        }


        [HttpPost]
        public IActionResult AddRating(int score, int productId,int userId)
        {
            
            var ratingsByProductAndUserId = _productRatingService.GetRatingsByProductAndUserId(productId, userId);

            var order = _orderService.GetOrdersByUserId(userId).FirstOrDefault(o => o.ProductId == productId);
            if (order == null)
            {
                TempData["ErrorMessage"] = "Sadece satın aldığınız ürünlere puan verebilirsiniz.";
                return RedirectToAction("ProductDetails", "Product", new { id = productId });
            }

            if (ratingsByProductAndUserId != null)
            {
               
                _productRatingService.UpdateProductRating(productId,userId,score);
            }
            else
            {
                var rating = new ProductRatingDto
                {
                    ProductId = productId,
                    Score = score,
                    UserId = userId
                };

                _productRatingService.AddProductRating(rating);
            }

        

            return RedirectToAction("ProductDetails", "Product", new { id = productId });
        }


    }
}
