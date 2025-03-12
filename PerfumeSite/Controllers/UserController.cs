 using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.UserViewModels;
using System.Net.Mail;
using System.Net;
using BLL.ConcreteServices;

namespace PerfumeSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserController(IUserService userService, IMapper mapper, IEmailService emailService)
        {
            _userService = userService;
            _mapper = mapper;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userLoginViewModel)
        {
            var loggedInUser = _userService.Login(_mapper.Map<UserLoginDto>(userLoginViewModel));
            if (loggedInUser == null)
            {
                ModelState.AddModelError(string.Empty, "Yanlış email veya şifre. Ama hangisi söylemem");
                return View("Login"); // Kullanıcıyı aynı görünüme geri döndürün
            }

            HttpContext.Session.SetInt32("Id", loggedInUser.Id);


            HttpContext.Session.SetString("IsAdmin", loggedInUser.IsAdmin.ToString());

            if (loggedInUser.IsAdmin)
            {

                return RedirectToAction("AdminHomePage", "Admin");


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }






        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var getByEmail = _userService.GetByEmail(userViewModel.Email);
            var getByPhoneNumber = _userService.GetByPhoneNumber(userViewModel.PhoneNumber);
            if (getByEmail != null)
            {
                ModelState.AddModelError("Email", "Bu email adresi ile kayıtlı bir kullanıcı var.");
                return View(userViewModel);
            }
            else if (getByPhoneNumber != null)
            {
                ModelState.AddModelError("PhoneNumber", "Bu telefon numarası ile kayıtlı bir kullanıcı var.");
                return View(userViewModel);
            }


            var userDto = _mapper.Map<UserDto>(userViewModel);



            _userService.SignUp(userDto);
            return RedirectToAction("Login");


        }








        public IActionResult ForgotPassword()
        {
            return View();
        }




        [HttpPost]
        public IActionResult ResetPassword(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                // Kullanıcı bulunamadı durumu
                return NotFound("Kullanıcı bulunamadı.");

            }

            _emailService.SendResetPasswordEmail(user.Email, user.Id);

            return RedirectToAction("Login");

        }


        [HttpGet]
        public IActionResult ResetPassword(int id)
        {



            ViewBag.id = id;





            return View();
        }




        [HttpPost]
        public IActionResult UpdatePasswordWithoutCheck(int id, UserViewModel userViewModel)
        {

            var user = _userService.GetById(id);
            user.Password = userViewModel.Password;

            _userService.UpdatePasswordWithOutCheck(user);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult MyAccount()
        {

            var userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("Login");

            }


            return View();
        }




        [HttpGet]
        public IActionResult AccountSettings()
        {
            return View();
        }




        [HttpGet]
        public IActionResult GetUserProfile()
        {
            var user = _userService.GetLoggedInUser(HttpContext.Session.GetInt32("Id"));

           var userProfile =   _userService.GetUserProfile(user.Id);


            var userUpdatePasswordViewModel = new UserUpdatePasswordViewModel();
          


            var tuple = Tuple.Create(_mapper.Map<UserProfileViewModel>(userProfile),userUpdatePasswordViewModel);


            return View(tuple);
        }

        [HttpPost]
        public IActionResult UpdateUserProfile(UserProfileViewModel userProfileViewModel)
        {

            _userService.UpdateUserProfile(_mapper.Map<UserProfileDto>(userProfileViewModel));

            return RedirectToAction("GetUserProfile");

        }



        [HttpPost]
        public IActionResult UpdatePasswordWithCheck(UserUpdatePasswordViewModel userUpdatePasswordViewModel)
        {



            var user = _userService.GetLoggedInUser(HttpContext.Session.GetInt32("Id"));

            var updatePasswordDto = new UserUpdatePasswordDto
            {
                Id = user.Id,
                NewPassword = userUpdatePasswordViewModel.NewPassword
            };


           


              _userService.UpdatePasswordWithCheck(updatePasswordDto);

            return RedirectToAction("Login");
           
            




            

        }
       

    }
}
