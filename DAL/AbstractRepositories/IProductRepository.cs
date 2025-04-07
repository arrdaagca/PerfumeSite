using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AbstractRepositories
{
    public interface IProductRepository
    {


        List<Product> GetAllProducts();
        List<Product> SearchProducts(string query);
    }
}
