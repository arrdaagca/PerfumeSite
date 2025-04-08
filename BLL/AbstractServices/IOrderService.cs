using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IOrderService
    {


        void AddOrder(OrderDto orderDto);
        List<OrderDto> GetOrdersByUserId(int? userId);
        void DeleteOrder(int id);





    }
}
