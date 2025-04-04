using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IFavoriteService
    {
        void AddFavorite(FavoriteDto favoriteDto);

        List<FavoriteDto> GetFavoritesByUserId(int userId);



        void RemoveFavorite(int userId, int productId); 


        bool IsFavorite(int userId, int productId);


    }
}
