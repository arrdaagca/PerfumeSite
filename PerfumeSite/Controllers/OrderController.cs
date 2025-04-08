using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeSite.CommentViewModels;
using PerfumeSite.OrderViewModels;
using PerfumeSite.ProductViewModels;

namespace PerfumeSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public OrderController(IOrderService orderService,IMapper mapper,IProductService productService,IBasketService basketService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _productService = productService;
            _basketService = basketService;
        }




        [HttpGet]
        public IActionResult GetOrders()
        {
            var userId = HttpContext.Session.GetInt32("Id");

            var allOrders = _orderService.GetOrdersByUserId(userId);


            var orderProductTuples = allOrders.Select(order =>
            {
                var orderViewModel = _mapper.Map<OrderViewModel>(order);

                var product = _productService.GetById(order.ProductId);
                var productViewModel = _mapper.Map<ProductViewModel>(product);

                return Tuple.Create(orderViewModel, productViewModel);
            }).ToList();

            return View(orderProductTuples);


        }














        [HttpPost]
        public IActionResult ConfirmOrder(int AddressId, int CreditCardId, int UserId, List<int> ProductId,int Quantity)
        {
            var userId = (int)HttpContext.Session.GetInt32("Id");

            foreach (var productId in ProductId)
            {
                var orderViewModel = new OrderViewModel
                {
                    AddressId = AddressId,
                    CreditCardId = CreditCardId,
                    UserId = UserId,
                    ProductId = productId,
                    Quantity = Quantity
                };

                var order = _mapper.Map<OrderDto>(orderViewModel);

                _orderService.AddOrder(_mapper.Map<OrderDto>(order));
                _basketService.RemoveBasket(userId, productId);

            }



            return View();
        }



    }
}
