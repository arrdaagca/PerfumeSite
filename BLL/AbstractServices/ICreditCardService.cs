using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface ICreditCardService
    {

        void AddCreditCard(AddCreditCardDto addCreditCardDto);  


        List<CreditCardDto> GetCreditCardsByUserId(int? userId);


        void DeleteCreditCard(int id);

        void EditCreditCard(CreditCardDto creditCardDto);   




    }
}
