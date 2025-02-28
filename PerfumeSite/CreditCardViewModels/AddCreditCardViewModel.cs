using PerfumeSite.UserViewModels;

namespace PerfumeSite.CreditCardViewModels
{
    public class AddCreditCardViewModel : BaseViewModel
    {
        public string CreditCardNumber { get; set; }
        public string CreditCardValidityDate { get; set; }
        public string CreditCardVerificationCode { get; set; }

        public int UserId { get; set; }
    }
}
