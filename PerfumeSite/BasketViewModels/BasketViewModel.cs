using PerfumeSite.UserViewModels;

namespace PerfumeSite.BasketViewModels
{
    public class BasketViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }
        public decimal Price { get; set; }



    }
}
