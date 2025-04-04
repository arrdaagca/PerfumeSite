using AutoMapper;
using BLL.AbstractServices;
using BLL.AllDtos;
using DAL.AbstractRepositories;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IGenericRepository<Favorite> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IGenericRepository<Favorite> genericRepository,IMapper mapper,IFavoriteRepository favoriteRepository)
        {
           _genericRepository = genericRepository;
           _mapper = mapper;
           _favoriteRepository = favoriteRepository;
        }



        public void AddFavorite(FavoriteDto favoriteDto)
        {
           _genericRepository.Add(_mapper.Map<Favorite>(favoriteDto));
        }

        public List<FavoriteDto> GetFavoritesByUserId(int userId)
        {
            var favorites = _favoriteRepository.GetFavoritesByUserId(userId);
            return _mapper.Map<List<FavoriteDto>>(favorites);
        }

        public bool IsFavorite(int userId, int productId)
        {

            return _favoriteRepository.IsFavorite(userId,productId);

        }

        public void RemoveFavorite(int userId, int productId)
        {
            var removeFavorite = _genericRepository.GetAll().FirstOrDefault(f => f.UserId == userId && f.ProductId == productId);
            _genericRepository.DeleteById(removeFavorite.Id);
        }
    }
}

