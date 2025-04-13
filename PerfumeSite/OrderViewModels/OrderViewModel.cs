using BLL.AllDtos;
using PerfumeSite.AddressViewModels;
using PerfumeSite.CreditCardViewModels;
using PerfumeSite.ProductViewModels;
using PerfumeSite.UserViewModels;

namespace PerfumeSite.OrderViewModels
{
    public class OrderViewModel : BaseViewModel
    {



        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        public int AddressId { get; set; }
        public AddressViewModel Address { get; set; }
        public int CreditCardId { get; set; }
        public CreditCardViewModel CreditCard { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;




    }
}
