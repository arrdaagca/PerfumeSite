using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using BLL.ConcreteServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.BasketViewModels;
using PerfumeSite.BrandViewModels;
using PerfumeSite.CategoryViewModels;
using PerfumeSite.CommentViewModels;
using PerfumeSite.ProductViewModels;

namespace PerfumeSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IFavoriteService _favoriteService;
        private readonly IBasketService _basketService;
        private readonly IProductRatingService _productRatingService;

        public ProductController(IProductService productService, IMapper mapper, IBrandService brandService, ICategoryService categoryService,ICommentService commentService,IUserService userService,IFavoriteService favoriteService,IBasketService basketService,IProductRatingService productRatingService)
        {
            _productService = productService;
            _mapper = mapper;
            _brandService = brandService;
            _categoryService = categoryService;
            _commentService = commentService;
            _userService = userService;
            _favoriteService = favoriteService;
            _basketService = basketService;
            _productRatingService = productRatingService;
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
        public IActionResult AddProduct(ProductViewModel addProductViewModel, IFormFile ImageFile)
        {

           
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError("Image", "Lütfen bir resim seçiniz.");
                return View(addProductViewModel);
            }

            
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                ImageFile.CopyTo(stream); 
            }

            
            addProductViewModel.Image = "/uploads/" + fileName;


            _productService.AddProduct(_mapper.Map<ProductDto>(addProductViewModel));
            return RedirectToAction("GetProducts");
        }



        [HttpGet]
        public IActionResult GetProducts()
        {
            var allProducts = _productService.GetAllProducts();

            var allBrands = _brandService.GetAllBrands();
            var allCategories = _categoryService.GetAllCategories();

          

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


            var products = _mapper.Map<List<ProductViewModel>>(allProducts);


            return View(products);
        }




        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteById(id);
            return RedirectToAction("GetProducts");
        }


        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var allBrands = _brandService.GetAllBrands();
            var allCategories = _categoryService.GetAllCategories();

            ViewBag.Brands = allBrands;
            ViewBag.Categories = allCategories;

            var updateProduct = _productService.GetById(id);


            return View(_mapper.Map<ProductViewModel>(updateProduct));
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductViewModel productViewModel, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                ModelState.AddModelError("Image", "Lütfen bir resim seçiniz.");
                return View(productViewModel); 
            }

            var fileName = Path.GetFileName(image.FileName); 
            var filePath = Path.Combine("wwwroot/uploads", fileName); 

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream); 
            }

            productViewModel.Image = "/uploads/" + fileName; 

            _productService.UpdateProduct(_mapper.Map<ProductDto>(productViewModel));

            return RedirectToAction("GetProducts"); 
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            var userId = HttpContext.Session.GetInt32("Id"); 

            var productDetail = _productService.GetById(id);

            var allCategories = _categoryService.GetAllCategories();
            var allBrands = _brandService.GetAllBrands();

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

            var comments = _commentService.GetCommentsByProductId(id);

            var commentViewModels = comments.Select(c => new CommentViewModel
            {
                UserId = c.UserId,
                ProductId = c.ProductId,
                CommentText = c.CommentText,
                CreatedDate = c.CreatedDate,
                UserName = _userService.GetById(c.UserId).UserName
            }).ToList();

            ViewBag.Comments = commentViewModels;

            var ratings = _productRatingService.GetRatingsByProductId(id);

            double averageRating = 0;

            if (ratings != null && ratings.Any())
            {
                averageRating = ratings.Average(r => r.Score);
            }

            ViewBag.AverageRating = averageRating;

            ViewBag.IsFavorite = userId != null && _favoriteService.IsFavorite(userId.Value, id);
            ViewBag.IsBasket = userId != null && _basketService.IsBasket(userId.Value, id);

            var commentViewModel = new CommentViewModel
            {
                ProductId = id
            };

            BasketViewModel basketViewModel = null;
            if (userId != null)
            {
                basketViewModel = new BasketViewModel
                {
                    ProductId = id,
                    UserId = userId.Value
                };
            }
            else
            {
                basketViewModel = new BasketViewModel(); 
            }

            var viewModel = Tuple.Create(_mapper.Map<ProductViewModel>(productDetail), commentViewModel, basketViewModel);

            return View(viewModel);
        }





        [HttpGet]
        public IActionResult Search(string query)
        {
            
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index", "Home"); 
            }

            var results = _productService.SearchProducts(query);

            
            var viewModelResults = results.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.Image,
                Description = p.Description,
            }).ToList();

            
            if (!viewModelResults.Any())
            {
                ViewBag.Message = "Ürün bulunamadı."; 
            }

            
            return RedirectToAction("Index", "Home", new { query = query, results = viewModelResults });
        }















    }
}