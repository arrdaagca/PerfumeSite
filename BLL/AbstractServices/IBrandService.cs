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


        BrandDto GetById(int id);
        void UpdateBrand(BrandDto brandDto);
        List<BrandDto> GetAllBrands();

    }
}
