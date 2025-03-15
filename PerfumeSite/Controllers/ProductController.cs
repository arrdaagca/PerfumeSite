using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.ProductViewModels;

namespace PerfumeSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService,IMapper mapper,IBrandService brandService,ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _brandService = brandService;
            _categoryService = categoryService;
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            var allBrands = _brandService.GetAllBrands();
            var allCategories = _categoryService.GetAllCategories();

            ViewBag.Brands = allBrands;
            ViewBag.Categories = allCategories;

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel addProductViewModel,IFormFile ImageFile)
        {
          
            // 2️⃣ Resim dosyasını kontrol et
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError("Image", "Lütfen bir resim seçiniz.");
                return View(addProductViewModel);
            }

            // 3️⃣ Dosya adını oluştur
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

            // 4️⃣ Dosyayı wwwroot içine kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                ImageFile.CopyTo(stream); // Senkron olarak dosyayı kopyala
            }

            // 5️⃣ DTO içindeki Image alanına dosya yolunu ata
            addProductViewModel.Image = "/uploads/" + fileName;


            _productService.AddProduct(_mapper.Map<ProductDto>(addProductViewModel));
            return View();
        }



        [HttpGet]
        public IActionResult GetProducts(int id)
        {
          var allProducts = _productService.GetAllProducts();

           


            var products = _mapper.Map<List<ProductViewModel>>(allProducts);


            return View(products);
        }


    }
}
