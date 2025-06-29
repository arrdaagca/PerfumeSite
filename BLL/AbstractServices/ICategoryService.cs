﻿using BLL.AllDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface ICategoryService
    {

        void AddCategory(CategoryDto addCategoryDto);

       

        void UpdateCategory(CategoryDto categoryDto);


        CategoryDto GetById(int id);

        List<CategoryDto> GetAllCategories();


    }
}
