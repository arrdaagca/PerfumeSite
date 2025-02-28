using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AllDtos
{
    public class AddCreditCardDto : BaseDto
    {

        public string CreditCardNumber { get; set; }
        public string CreditCardValidityDate { get; set; }
        public string CreditCardVerificationCode { get; set; }

        public int UserId { get; set; }


    }
}
