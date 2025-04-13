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
    public class ProductRatingService : IProductRatingService
    {
        private readonly IGenericRepository<ProductRating> _genericRepository;
        private readonly IMapper _mapper;

        public ProductRatingService(IGenericRepository<ProductRating> genericRepository,IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }




        public void AddProductRating(ProductRatingDto productRatingDto)
        {
            var rating = _mapper.Map<ProductRating>(productRatingDto);
            _genericRepository.Add(rating);
        }

       

        public double GetAverageRating(int productId)
        {
            var ratings = _genericRepository.GetAll().Where(r => r.ProductId == productId);

            if (!ratings.Any())
                return 0;

            return ratings.Average(r => r.Score);

        }

        public ProductRatingDto GetRatingsByProductAndUserId(int productId, int userId)
        {
           var rating = _genericRepository.GetAll()
                .FirstOrDefault(r => r.ProductId == productId && r.UserId == userId);
            if (rating == null)
                return null;
            return _mapper.Map<ProductRatingDto>(rating);
        }

        public List<ProductRating> GetRatingsByProductId(int productId)
        {
            return _genericRepository.GetAll().Where(r => r.ProductId == productId).ToList();
        }

        public void UpdateProductRating(int productId, int userId, int newScore)
        {
            var rating = _genericRepository.GetAll()
        .FirstOrDefault(r => r.ProductId == productId && r.UserId == userId);

            if (rating != null)
            {
                rating.Score = newScore;
                _genericRepository.Update(rating);
                
            }
        }
    }
    
}
