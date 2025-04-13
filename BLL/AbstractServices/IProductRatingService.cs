using BLL.AllDtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IProductRatingService
    {


        void AddProductRating(ProductRatingDto productRatingDto);



        List<ProductRating> GetRatingsByProductId(int productId);
        ProductRatingDto GetRatingsByProductAndUserId(int productId,int userId);

       void UpdateProductRating(int productId, int userId, int newScore);

        double GetAverageRating(int productId);

    }
}
