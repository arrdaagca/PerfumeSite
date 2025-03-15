using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.BrandViewModels;

namespace PerfumeSite.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService,IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddBrand(AddBrandViewModel addBrandViewModel)
        {

            _brandService.AddBrand(_mapper.Map<BrandDto>(addBrandViewModel));

            return View();
        }


        [HttpGet]
        public IActionResult GetAllBrands()
        {

            var allBrands = _brandService.GetAllBrands();

            return View(_mapper.Map<List<AddBrandViewModel>>(allBrands));
        }


        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {

         var updateBrand =    _brandService.GetById(id);



            return View(_mapper.Map<AddBrandViewModel>(updateBrand));
        }
        [HttpPost]
        public IActionResult UpdateBrand(AddBrandViewModel addBrandViewModel)
        {

            _brandService.UpdateBrand(_mapper.Map<BrandDto>(addBrandViewModel));

            return RedirectToAction("GetAllBrands");
        }


    }
}
