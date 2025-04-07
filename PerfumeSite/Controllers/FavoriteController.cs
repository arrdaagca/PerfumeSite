using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using BLL.ConcreteServices;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.BrandViewModels;
using PerfumeSite.FavoriteViewModels;
using PerfumeSite.ProductViewModels;

namespace PerfumeSite.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;

        public FavoriteController(IFavoriteService favoriteService,IMapper mapper,IProductService productService,IBrandService brandService)
        {
            _favoriteService = favoriteService;
            _mapper = mapper;
            _productService = productService;
            _brandService = brandService;
        }

        [HttpPost]
        public IActionResult AddFavorite(FavoriteViewModel favoriteViewModel,int productId)
        {
            var userId = HttpContext.Session.GetInt32("Id");


        


            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }


            var IsFavorite = _favoriteService.IsFavorite((int)userId, productId);

            if (IsFavorite == true)
            {
                return RedirectToAction("Index","Home");
            }

            var favorite = _mapper.Map<FavoriteDto>(favoriteViewModel);
            _favoriteService.AddFavorite(favorite);

            return RedirectToAction("Get Favorites");
        }



        [HttpPost]
        public IActionResult RemoveFavorite(int productId)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            if (userId == null) 
            {
                return RedirectToAction("Login", "User");
            }
            _favoriteService.RemoveFavorite((int)userId, productId);
            return RedirectToAction("Index", "Home");
        }

         

        [HttpGet]
        public IActionResult GetFavorites()
        {
            var allBrands = _brandService.GetAllBrands();

            var brandViewModels = allBrands.Select(b => new AddBrandViewModel
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();

            ViewBag.Brands = brandViewModels;




            var userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("Login", "User");
            }

            var favoriteEntities = _favoriteService.GetFavoritesByUserId(userId.Value);

            var favoriteProducts = new List<Tuple<ProductViewModel, FavoriteViewModel>>();

            foreach (var favorite in favoriteEntities)
            {
                var product = _productService.GetById(favorite.ProductId);

                var productViewModel = _mapper.Map<ProductViewModel>(product);
                var favoriteViewModel = _mapper.Map<FavoriteViewModel>(favorite);

                favoriteProducts.Add(Tuple.Create(productViewModel, favoriteViewModel));
            }

            return View(favoriteProducts);
        }


    }
}
