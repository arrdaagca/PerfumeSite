using AutoMapper;
using BLL.AbstractServices;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.AddressViewModels;
using PerfumeSite.FavoriteViewModels;
using PerfumeSite.UserViewModels;

namespace PerfumeSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;
        private readonly IFavoriteService _favoriteService;

        public AdminController(IUserService userService,IMapper mapper,IAddressService addressService)
        {
            _userService = userService;
            _mapper = mapper;
            _addressService = addressService;
        }
        [HttpGet]
        public IActionResult AdminHomePage()
        {

            return View();

        }

       

        [HttpGet]
        public IActionResult GetAllUsers()
        {

           var allUsers =   _userService.GetAllUsers();

            var getAllUsers = _mapper.Map<List<GetAllUsersViewModel>>(allUsers);

            return View(getAllUsers);
        }




        [HttpPost]
        public IActionResult EnterUserId(int enterUserId,AddAddressViewModel addAddressViewModel)
        {

            var userId= _userService.GetById(enterUserId);

            var getUserAddress = _addressService.GetAddressByUserId(enterUserId);

            if (userId == null)
            {
                TempData["Message"] = "Kullanıcı Bulunamadı!";
                return RedirectToAction("GetUserAddressByAdmin");
            }
            else if(getUserAddress.Count == 0) 
            {
                TempData["Message2"] = "Kullanıcıya Ait Adres Bilgisi Bulunamadı!";
                return RedirectToAction("GetUserAddressByAdmin");
                
            }

            else if (enterUserId == userId.Id)
            {
                return RedirectToAction("GetUserAddressByAdmin",new { enterUserId });
            }
            
                return null;
            

        }





        [HttpGet]
        public IActionResult GetUserAddressByAdmin(int enterUserId)
        {
            ViewBag.UserId = enterUserId;

            


            var getUserAddress = _addressService.GetAddressByUserId(enterUserId);
            

            
            var addressViewModelList = _mapper.Map<List<AddressViewModel>>(getUserAddress);

            return View(addressViewModelList);
        }


    }
}
