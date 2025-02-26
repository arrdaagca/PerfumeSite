using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class UserCreditCardDto
    {
        public string CreditCardNumber { get; set; }
        public string CreditCardValidityDate { get; set; }
        public string CreditCardVerificationCode { get; set; }

    }
}
