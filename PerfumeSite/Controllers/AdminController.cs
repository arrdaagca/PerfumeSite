using AutoMapper;
using BLL.AbstractServices;
using Microsoft.AspNetCore.Mvc;

namespace PerfumeSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdminController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
