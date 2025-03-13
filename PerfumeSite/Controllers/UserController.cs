 using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.UserViewModels;
using System.Net.Mail;
using System.Net;
using BLL.ConcreteServices;
using BCrypt.Net;

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
                return View("Login"); 
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
            var getByUserName = _userService.GetByUserName(userViewModel.UserName);
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
            else if (getByUserName != null)
            {
                ModelState.AddModelError("UserName", "Bu kullanıcı adı ile kayıtlı bir kullanıcı var.");
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
                ViewBag.ErrorMessage = "Kullanıcı bulunamadı.";
                 return View("ForgotPassword");

            }

            _emailService.SendResetPasswordEmail(user.Email, user.Id);

            return RedirectToAction("Login");

        }


        [HttpGet]
        public IActionResult ResetPassword()
        {


            




            return View();
        }



        [HttpPost]
        public IActionResult UpdatePasswordWithoutCheck(int id, UserViewModel userViewModel)
        {
            if (string.IsNullOrWhiteSpace(userViewModel.Password) || userViewModel.Password.Length < 8 ||
          !System.Text.RegularExpressions.Regex.IsMatch(userViewModel.Password, @"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])"))
            {
                TempData["ErrorMessage"] = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.";
                return RedirectToAction("ResetPassword");
            }

            var user = _userService.GetById(userViewModel.Id);
           
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
            var getByUserName = _userService.GetByUserName(userProfileViewModel.UserName);
            var getByPhoneNumber = _userService.GetByPhoneNumber(userProfileViewModel.PhoneNumber);
            var getByEmail = _userService.GetByEmail(userProfileViewModel.Email);
            var userId = HttpContext.Session.GetInt32("Id");

                 
            
            if (getByEmail != null && getByEmail.Id != userId)
            {

                TempData["ErrorMessage"] = "Bu email adresi ile kayıtlı bir kullanıcı var.";
                return RedirectToAction("GetUserProfile");
            }            
            else if (getByPhoneNumber != null && getByPhoneNumber.Id != userId)
            {
                TempData["ErrorMessage"] = "Bu telefon numarası ile kayıtlı bir kullanıcı var.";
                return RedirectToAction("GetUserProfile");
            }
            else if (getByUserName != null && getByUserName.Id != userId)
            {
                TempData["ErrorMessage"] = "Bu kullanıcı adı ile kayıtlı bir kullanıcı var.";
                return RedirectToAction("GetUserProfile");
            }
            
            _userService.UpdateUserProfile(_mapper.Map<UserProfileDto>(userProfileViewModel));
            TempData["SuccessMessage"] = "Profil başarıyla güncellendi.";

            return RedirectToAction("GetUserProfile");
        }





        [HttpPost]
        public IActionResult UpdatePasswordWithCheck(UserUpdatePasswordViewModel userUpdatePasswordViewModel)
        {

            if (!ModelState.IsValid)
            {
                // Hataları TempData'ya ekleyerek geri gönder
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        TempData["ErrorMessage"] += error.ErrorMessage + " ";
                    }
                }
                return RedirectToAction("GetUserProfile");
            }




            var userId = HttpContext.Session.GetInt32("Id");
            

            var user = _userService.GetLoggedInUser(userId.Value);

           
            if (userUpdatePasswordViewModel.NewPassword != userUpdatePasswordViewModel.ConfirmNewPassword)
            {
                TempData["ErrorMessage"] = "Yeni şifreler eşleşmiyor.";
                return RedirectToAction("GetUserProfile");
            }

            if (!BCrypt.Net.BCrypt.Verify(userUpdatePasswordViewModel.Password, user.Password))
            {
                TempData["ErrorMessage"] = "Mevcut şifre doğru değil.";
                return RedirectToAction("GetUserProfile");
            }

            var updatePasswordDto = new UserUpdatePasswordDto
            {
                Id = user.Id,
                NewPassword = userUpdatePasswordViewModel.NewPassword
            };
            _userService.UpdatePasswordWithCheck(updatePasswordDto);

            TempData["SuccessMessage"] = "Şifre başarıyla güncellendi.";
            return RedirectToAction("Login");
        }











    }


}

