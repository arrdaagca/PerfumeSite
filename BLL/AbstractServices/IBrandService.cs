using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IBrandService
    {


        void AddBrand(BrandDto addBrandDto);

        

        List<BrandDto> GetAllBrands();

    }
}
