using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeSite.BasketViewModels;
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


           


            var orderProductBasketTuples = allOrders.Select(order =>
            {
                var orderViewModel = _mapper.Map<OrderViewModel>(order);

                var product = _productService.GetById(order.ProductId);
                var productViewModel = _mapper.Map<ProductViewModel>(product);

               

                return Tuple.Create(orderViewModel, productViewModel);
            }).ToList();
            
            return View(orderProductBasketTuples);
        }







        [HttpPost]
        public IActionResult ConfirmOrder(int AddressId, int CreditCardId, int UserId, List<int> ProductId, List<int> Quantity)
        {
            var userId = (int)HttpContext.Session.GetInt32("Id");
            decimal kargoUcreti = 100;

            for (int i = 0; i < ProductId.Count; i++)
            {
                var product = _productService.GetById(ProductId[i]);
                if (product.Stock < Quantity[i])
                {
                    TempData["StockError"] = $"'{product.Name}' ürününden stokta yeterli miktarda kalmamış.";
                    return RedirectToAction("ConfirmBasket", "Basket");
                }
            }

            decimal toplamTutar = 0;

            for (int i = 0; i < ProductId.Count; i++)
            {
                var productId = ProductId[i];
                var quantity = Quantity[i];

                var product = _productService.GetById(productId);
                var basket = _basketService.GetBasketByUserId(userId).FirstOrDefault(b => b.ProductId == productId);

             
                var orderViewModel = new OrderViewModel
                {
                    AddressId = AddressId,
                    CreditCardId = CreditCardId,
                    UserId = userId, 
                    ProductId = productId,
                    Quantity = quantity,
                    TotalPrice = (basket.Price * quantity) + kargoUcreti
                };

                toplamTutar += orderViewModel.TotalPrice;

                var order = _mapper.Map<OrderDto>(orderViewModel);

                product.Stock -= quantity;
                _productService.UpdateProduct(_mapper.Map<ProductDto>(product));

                _orderService.AddOrder(order);

                _basketService.RemoveBasket(userId, productId);
            }

            TempData["TotalPrice"] = toplamTutar.ToString("F2"); 
            TempData["KargoUcreti"] = kargoUcreti.ToString("F2"); 

            return RedirectToAction("GetOrders","Order");
        }








    }
}
