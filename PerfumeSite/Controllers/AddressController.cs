using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeSite.AddressViewModels;

namespace PerfumeSite.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService,IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }


        

        [HttpGet]
        public IActionResult Address()
        {

           



            return View();
        }


        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(AddressViewModel addressViewModel)
{
    if (addressViewModel == null)
    {
        return BadRequest("Adres bilgileri eksik!");
    }

    // Kullanıcı oturumdan alınıyor
    var userId = HttpContext.Session.GetInt32("UserId");
    if (userId == null)
    {
        return RedirectToAction("Login", "User"); // Kullanıcı giriş yapmamışsa giriş sayfasına yönlendir
    }

    // Kullanıcı ID'yi modele ekle
    addressViewModel.UserId = userId.Value;

    // Modeli AddressDto'ya çevir
    var addressDto = _mapper.Map<AddressDto>(addressViewModel);

    // Adres ekleme işlemi
    _addressService.AddAddress(addressDto);

    return RedirectToAction("Address"); // Başarılı ekleme sonrası yönlendirme
}


    }
}
