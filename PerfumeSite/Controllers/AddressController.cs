using AutoMapper;
using BLL.AbstractServices;
using BLL.ConcreteServices;
using Microsoft.AspNetCore.Mvc;
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
        var userId = HttpContext.Session.GetInt32("Id");

        if (!userId.HasValue) // Kullanıcı giriş yapmamışsa
        {
            return RedirectToAction("Login", "User");
        }

        var addresses = _addressService.GetAddressByUserId(userId.Value);

        // AutoMapper kullanarak DTO'dan ViewModel'e çevirme
        var addressViewModels = _mapper.Map<List<AddressViewModel>>(addresses);

        return View(addressViewModels);
    }




}
}
