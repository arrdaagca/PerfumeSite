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

        [HttpPost]
        public IActionResult DeleteAddress(int id)
        {   HttpContext.Session.GetInt32("Id");
            _addressService.DeleteAddress(id);
            return RedirectToAction("Address");
        }
        [HttpGet]
        public IActionResult EditAddress(int id)
        {

           
            var address = _addressService.GetAddressByUserId( HttpContext.Session.GetInt32("Id")).FirstOrDefault(x => x.Id == id);

           

            return View(_mapper.Map<AddressViewModel>(address));
        }

        [HttpPost]
        public IActionResult EditAddress(AddressViewModel addressViewModel)
        {

            _addressService.EditAddress(_mapper.Map<AddressDto>(addressViewModel));
            return RedirectToAction("Address");


        }


    }
}
