using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
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
    
           
    
            var addresses = _addressService.GetAddressByUserId(userId.Value);
    
            
            var addressViewModels = _mapper.Map<List<AddressViewModel>>(addresses);
    
            return View(addressViewModels);
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(AddAddressViewModel addAddressViewModel)
        {
            _addressService.AddAddress(_mapper.Map<AddAddressDto>(addAddressViewModel));
            return RedirectToAction("Address");
        }
    }
}
