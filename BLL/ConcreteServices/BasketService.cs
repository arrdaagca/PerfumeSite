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
    public class BasketService : IBasketService
    {
        private readonly IGenericRepository<Basket> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;

        public BasketService(IGenericRepository<Basket> genericRepository,IMapper mapper,IBasketRepository basketRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _basketRepository = basketRepository;
        }






        public void AddBasket(BasketDto basketDto)
        {
            _genericRepository.Add(_mapper.Map<Basket>(basketDto));
        }

        public List<BasketDto> GetBasketByUserId(int userId)
        {
            var baskets = _basketRepository.GetBasketByUserId(userId);
            return _mapper.Map<List<BasketDto>>(baskets);
        }

        public bool IsBasket(int userId, int productId)
        {
            return _basketRepository.IsBasket(userId, productId);
        }

        public void RemoveBasket(int userId, int productId)
        {
            var removeBasket = _genericRepository.GetAll().FirstOrDefault(f => f.UserId == userId && f.ProductId == productId);
            _genericRepository.DeleteById(removeBasket.Id);
        }
    }
}
