using PerfumeSite.UserViewModels;

namespace PerfumeSite.AddressViewModels
{
    public class AddAddressViewModel : BaseViewModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int DoorNumber { get; set; }


        public int UserId { get; set; }
    }
}
