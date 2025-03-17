using AutoMapper;
using BLL.AbstractServices;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.ProductViewModels;

namespace PerfumeSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public HomeController(IMapper mapper,IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public IActionResult Index()
        {

          var getAllProducts =   _productService.GetAllProducts();


            return View(_mapper.Map<List<ProductViewModel>>(getAllProducts));
        }
    }
}
