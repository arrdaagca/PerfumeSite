using PerfumeSite.UserViewModels;

namespace PerfumeSite.FavoriteViewModels
{
    public class FavoriteViewModel : BaseViewModel
    {

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;




    }
}
