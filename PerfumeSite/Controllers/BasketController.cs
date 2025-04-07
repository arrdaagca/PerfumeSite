using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using BLL.ConcreteServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.BasketViewModels;
using PerfumeSite.BrandViewModels;
using PerfumeSite.FavoriteViewModels;
using PerfumeSite.ProductViewModels;

namespace PerfumeSite.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;

        public BasketController(IBasketService basketService,IMapper mapper,IBrandService brandService,IProductService productService)
        {
            _basketService = basketService;
            _mapper = mapper;
            _brandService = brandService;
            _productService = productService;
        }




        [HttpPost]
        public IActionResult AddBasket(BasketViewModel basketViewModel,int productId)
        {
            var userId = HttpContext.Session.GetInt32("Id");




            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }
            var IsBasket = _basketService.IsBasket((int)userId, productId);

            if (IsBasket == true)
            {
                return RedirectToAction("Index", "Home");
            }


            var basket = _mapper.Map<BasketDto>(basketViewModel);
            _basketService.AddBasket(basket);


            return RedirectToAction("GetBasket");
        }



        [HttpPost]
        public IActionResult RemoveBasket(int productId)
        {

            var userId = HttpContext.Session.GetInt32("Id");
            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }
            _basketService.RemoveBasket((int)userId, productId);
            return RedirectToAction("Index", "Home");


        }






        [HttpGet]
        public IActionResult GetBasket()
        {
            var userId = HttpContext.Session.GetInt32("Id");

            var allBrands = _brandService.GetAllBrands();

            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var brandViewModels = allBrands.Select(b => new AddBrandViewModel
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();

            ViewBag.Brands = brandViewModels;

            var basketEntities = _basketService.GetBasketByUserId(userId.Value);

            var basketProducts = new List<Tuple<ProductViewModel, BasketViewModel>>();

            foreach (var basket in basketEntities)
            {
                var product = _productService.GetById(basket.ProductId);

                var productViewModel = _mapper.Map<ProductViewModel>(product);
                var basketViewModel = _mapper.Map<BasketViewModel>(basket); 

                basketProducts.Add(Tuple.Create(productViewModel, basketViewModel));
            }

            return View(basketProducts);
        }

        [HttpGet]
        public IActionResult ConfirmBasket()
        {
            return View();
        }


    }
}
