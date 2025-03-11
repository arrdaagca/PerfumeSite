using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.AbstractRepositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class CreditCardService : ICreditCardService
    {
        private readonly IGenericRepository<CreditCard> _genericRepository;
        private readonly IMapper _mapper;
        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardService(IGenericRepository<CreditCard> genericRepository,IMapper mapper,ICreditCardRepository creditCardRepository )
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _creditCardRepository = creditCardRepository;
        }

        public void AddCreditCard(AddCreditCardDto addCreditCardDto)
        {
            _genericRepository.Add(_mapper.Map<CreditCard>(addCreditCardDto));
        }

        public void DeleteCreditCard(int id)
        {
            _genericRepository.DeleteById(id);
        }

        public void EditCreditCard(CreditCardDto creditCardDto)
        {
            var creditCard = _genericRepository.GetById(creditCardDto.Id);
            _mapper.Map(creditCardDto, creditCard);
            _genericRepository.Update(creditCard);
        }

        public List<CreditCardDto> GetCreditCardsByUserId(int? userId)
        {
            var getUsersCreditCards = _creditCardRepository.GetCreditCardByUserId(userId);
            return _mapper.Map<List<CreditCardDto>>(getUsersCreditCards);
        }
    }
}
