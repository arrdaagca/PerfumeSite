using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IBasketService
    {

        void AddBasket(BasketDto basketDto);

        List<BasketDto> GetBasketByUserId(int userId);


        bool IsBasket(int userId, int productId);

        void RemoveBasket(int userId, int productId);


    }
}
