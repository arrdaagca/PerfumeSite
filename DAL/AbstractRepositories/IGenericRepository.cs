using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AbstractRepositories
{
    public interface IGenericRepository<T> where T : BaseClass
    {

        void Add(T entity);
        void Update(T entity);

        void DeleteById(int id);

        T GetById(int id);
        List<T> GetAll();

    }
}
