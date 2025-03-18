using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IProductService
    {

        void AddProduct(ProductDto addProductDto);   

        List<ProductDto> GetAllProducts();

        void DeleteById(int id);


        

        void UpdateProduct(ProductDto productDto);

        ProductDto GetById(int id);

    }
}
