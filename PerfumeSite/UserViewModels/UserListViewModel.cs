namespace PerfumeSite.UserViewModels
{
    public class UserListViewModel : BaseViewModel
    {

        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
