using AutoMapper;
using BLL.AbstractServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PerfumeSite.BrandViewModels;
using PerfumeSite.CategoryViewModels;
using PerfumeSite.ProductViewModels;

namespace PerfumeSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IFavoriteService _favoriteService;

        public HomeController(IMapper mapper,IProductService productService,ICategoryService categoryService,IBrandService brandService,IFavoriteService favoriteService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _favoriteService = favoriteService;
        }

        public IActionResult Index(string sortOrder,string sortPrice,int? brandId,int? categoryId,int productId)
        {


            var userId = HttpContext.Session.GetInt32("Id");

            var getAllProducts =   _productService.GetAllProducts();
            var allBrands = _brandService.GetAllBrands();
            var allCategories = _categoryService.GetAllCategories();





            if (userId != null)
            {
                ViewBag.IsFavorite = _favoriteService.IsFavorite(userId.Value, productId);
            }
            else
            {
                ViewBag.IsFavorite = false;
            }







            if (categoryId.HasValue)
            {
                getAllProducts = getAllProducts.Where(x=>x.CategoryId == categoryId.Value).ToList();
            }


            if (brandId.HasValue)
            {
                getAllProducts = getAllProducts.Where(x=>x.BrandId == brandId.Value).ToList();
            }






            switch (sortOrder)
            {
                case "priceAsc":
                    getAllProducts = getAllProducts.OrderBy(x=>x.Price).ToList(); // Fiyat: Düşükten Yükseğe
                    break;
                case "priceDesc":
                    getAllProducts = getAllProducts.OrderByDescending(x=>x.Price).ToList(); // Fiyat: Yüksekten Düşüğe
                    break;
              
                default:
                    break; 
            }




            switch (sortPrice)
            {
                case "0-1000":
                    getAllProducts = getAllProducts.Where(x=>x.Price >= 0 && x.Price <= 1000).ToList();
                    break;
                case "1001-2000":
                    getAllProducts = getAllProducts.Where(x=>x.Price >= 1001 && x.Price <= 2000).ToList();
                    break;
                case "2001-10000":
                    getAllProducts = getAllProducts.Where(x=>x.Price >= 2001 && x.Price <= 10000).ToList();
                    break;
                default:
                    break; 
            }




            var brandViewModels = allBrands.Select(b => new AddBrandViewModel
            {
                Id = b.Id,
                Name = b.Name

            }).ToList();

            var categoryViewModels = allCategories.Select(c => new AddCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name

            }).ToList();

            ViewBag.Brands = brandViewModels;
            ViewBag.Categories = categoryViewModels;
            

            return View(_mapper.Map<List<ProductViewModel>>(getAllProducts));
        }
    }
}
