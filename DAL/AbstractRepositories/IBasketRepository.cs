﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AbstractRepositories
{
    public interface IBasketRepository
    {



        List<Basket> GetBasketByUserId(int? userId);

        bool IsBasket(int userId, int productId);

    }
}
