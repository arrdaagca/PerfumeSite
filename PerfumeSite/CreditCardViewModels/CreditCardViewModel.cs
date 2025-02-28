using BLL.AllDtos;
using PerfumeSite.UserViewModels;

namespace PerfumeSite.CreditCardViewModels
{
    public class CreditCardViewModel : BaseViewModel
    {
        public string CreditCardNumber { get; set; }
        public string CreditCardValidityDate { get; set; }
        public string CreditCardVerificationCode { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }

    }
}
