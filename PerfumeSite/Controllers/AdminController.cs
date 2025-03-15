using AutoMapper;
using BLL.AbstractServices;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.UserViewModels;

namespace PerfumeSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdminController(IUserService userService,IMapper mapper )
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AdminHomePage()
        {

            return View();

        }

        [HttpGet]
        public IActionResult GetProducts()
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



    }
}
