using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using BLL.ConcreteServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.AddressViewModels;
using PerfumeSite.BasketViewModels;
using PerfumeSite.BrandViewModels;
using PerfumeSite.CommentViewModels;
using PerfumeSite.CreditCardViewModels;
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
        private readonly IAddressService _addressService;
        private readonly ICreditCardService _creditCardService;
        private readonly IOrderService _orderService;

        public BasketController(IBasketService basketService,IMapper mapper,IBrandService brandService,IProductService productService,IAddressService addressService,ICreditCardService creditCardService,IOrderService orderService)
        {
            _basketService = basketService;
            _mapper = mapper;
            _brandService = brandService;
            _productService = productService;
            _addressService = addressService;
            _creditCardService = creditCardService;
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult AddBasket(BasketViewModel basketViewModel, int productId, decimal adjustedPrice)
        {
            var userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var isBasket = _basketService.IsBasket((int)userId, productId);

            if (isBasket)
            {
                return RedirectToAction("Index", "Home");
            }

            var basket = _mapper.Map<BasketDto>(basketViewModel);
            basket.Price = adjustedPrice; 

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
            return RedirectToAction("GetBasket");


        }

        [HttpGet]
        public IActionResult GetBasket()
        {
            var userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var basketEntities = _basketService.GetBasketByUserId(userId.Value);
            var basketProducts = new List<Tuple<ProductViewModel, BasketViewModel>>();

            foreach (var basket in basketEntities)
            {
                var product = _productService.GetById(basket.ProductId);
                var productViewModel = _mapper.Map<ProductViewModel>(product);

                basketProducts.Add(Tuple.Create(productViewModel, _mapper.Map<BasketViewModel>(basket)));
            }

            return View(basketProducts); 
        }





        [HttpGet]
        public IActionResult ConfirmBasket()
        {
            int? userId = HttpContext.Session.GetInt32("Id");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var allBrands = _brandService.GetAllBrands();
            var brandViewModels = _mapper.Map<List<AddBrandViewModel>>(allBrands);
            ViewBag.Brands = brandViewModels;

            

           




            var addresses = _addressService.GetAddressByUserId((int)userId);
            var addressViewModels = _mapper.Map<List<AddressViewModel>>(addresses);

            var cards = _creditCardService.GetCreditCardsByUserId((int)userId);
            var cardViewModels = _mapper.Map<List<CreditCardViewModel>>(cards);

            if (addresses == null || !addresses.Any() || cards == null || !cards.Any())
            {
                TempData["ErrorMessage"] = "Lütfen Adres ve Kredi Kartı Bilgilerinizi Ekleyiniz.";
            }


            var basketItems = _basketService.GetBasketByUserId((int)userId); 
            var viewModelList = new List<Tuple<AddressViewModel, CreditCardViewModel, ProductViewModel, BasketViewModel>>();

            foreach (var basket in basketItems)
            {
                var product = _productService.GetById(basket.ProductId);
                var productVm = _mapper.Map<ProductViewModel>(product);
                var basketVm = _mapper.Map<BasketViewModel>(basket);

                foreach (var address in addressViewModels)
                {
                    foreach (var card in cardViewModels)
                    {
                        viewModelList.Add(Tuple.Create(address, card, productVm, basketVm));
                    }
                }
            }

            return View(viewModelList);
        }


    }
}
