namespace PerfumeSite.UserViewModels
{
    public class GetAllUsersViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
