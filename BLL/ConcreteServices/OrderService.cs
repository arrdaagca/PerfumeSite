using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.AbstractRepositories;
using DAL.ConcreteRepositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IGenericRepository<Order> genericRepository,IMapper mapper,IOrderRepository orderRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }


        public void AddOrder(OrderDto orderDto)
        {
            _genericRepository.Add(_mapper.Map<Order>(orderDto));
           
        }

        public void DeleteOrder(int id)
        {
            var deleteOrder = _genericRepository.GetById(id);
            _genericRepository.DeleteById(id);
        }

        public List<OrderDto> GetOrdersByUserId(int? userId)
        {
            var orders = _orderRepository.GetOrdersByUserId(userId);
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
