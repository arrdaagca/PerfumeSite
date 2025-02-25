using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.UserViewModels;
using System.Net.Mail;
using System.Net;

namespace PerfumeSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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



            HttpContext.Session.SetInt32("Id", loggedInUser.Id);

            HttpContext.Session.SetString("Password", loggedInUser.Password);

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
            var userDto = _mapper.Map<UserDto>(userViewModel);


            _userService.SignUp(userDto);
            return RedirectToAction("Login");


        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }




        [HttpPost]
        public IActionResult ResetPassword(string email)
        {
            var user = _userService.GetByEmail(email);


            // Gönderen e-posta bilgileri
            string fromEmail = "arrdaagca@gmail.com";
            string password = "dqbd gdmn iadm ejkl";

            // Alıcı e-posta bilgileri
            string toEmail = user.Email;
            string subject = "Şifre Sıfırlama";
            string body = $"<a href=\"https://localhost:7292/User/ResetPassword?id={user.Id}\" style=\"color: blue; text-decoration: underline;\">Şifre sıfırlamak için tıklayınız.</a>";





            try
            {
                // SMTP istemcisi oluşturuluyor
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                // MailMessage nesnesi oluşturuluyor
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                // E-posta gönderimi
                smtpClient.Send(mailMessage);
                Console.WriteLine("E-posta başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            return View();
        }


        [HttpGet]
        public IActionResult ResetPassword(int id)
        {

            

            ViewBag.id = id;





            return View();
        }


        [HttpPost]
        public IActionResult UpdatePassword(int id, UserViewModel userViewModel)
        {

            var user = _userService.GetById(id);
            user.Password = userViewModel.Password;
            _userService.UpdatePassword(user);
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









    }
}
