using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;

namespace PerfumeSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel addCategoryViewModel)
        {

            _categoryService.AddCategory(_mapper.Map<CategoryDto>(addCategoryViewModel));


            return View();
        }


        [HttpGet]
        public IActionResult GetAllCategories()
        {

            var getAllCategories = _categoryService.GetAllCategories();


            return View(_mapper.Map<List<AddCategoryViewModel>>(getAllCategories));
        }


    }
}
