

using PerfumeSite.UserViewModels;

namespace PerfumeSite.UserViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

    }
}
