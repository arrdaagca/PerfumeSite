using PerfumeSite.UserViewModels;

namespace PerfumeSite.ProductRatingViewModels
{
    public class ProductRatingViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Score { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
