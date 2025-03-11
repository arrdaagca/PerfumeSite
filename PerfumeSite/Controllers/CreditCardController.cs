using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using Microsoft.AspNetCore.Mvc;
using PerfumeSite.CreditCardViewModels;

namespace PerfumeSite.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly ICreditCardService _creditCardService;
        private readonly IMapper _mapper;

        public CreditCardController(ICreditCardService creditCardService,IMapper mapper)
        {
            _creditCardService = creditCardService;
            _mapper = mapper;
        }




        [HttpGet]
        public IActionResult CreditCard()
        {

            var userId = HttpContext.Session.GetInt32("Id");    

            var creditCards = _creditCardService.GetCreditCardsByUserId(userId.Value);

            var creditCardViewModel =  _mapper.Map<List<CreditCardViewModel>>(creditCards); 


            return View(creditCardViewModel);
        }



        [HttpGet]
        public IActionResult AddCreditCard()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddCreditCard(AddCreditCardViewModel addCreditCardViewModel)
        {


            _creditCardService.AddCreditCard(_mapper.Map<AddCreditCardDto>(addCreditCardViewModel));



            return RedirectToAction("CreditCard");
        }

        [HttpPost]
        public IActionResult DeleteCreditCard(int id)
        {
            HttpContext.Session.GetInt32("Id");

            _creditCardService.DeleteCreditCard(id);

            return RedirectToAction("CreditCard");
        }


        [HttpGet]
        public IActionResult EditCreditCard(int id)
        {
            var creditCard = _creditCardService.GetCreditCardsByUserId(HttpContext.Session.GetInt32("Id")).FirstOrDefault(x=>x.Id == id);


            return View(_mapper.Map<CreditCardViewModel>(creditCard));
        
        }

        [HttpPost]
        public IActionResult EditCreditCard(CreditCardViewModel creditCardViewModel)
        {
            _creditCardService.EditCreditCard(_mapper.Map<CreditCardDto>(creditCardViewModel));
            return RedirectToAction("CreditCard");
        }

    }
}
