using _05_EF_example.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace data_access_entity.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //CRUD - creade , read, update , delete
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int Id);
        void Insert(TEntity entity);
        void Delete(int ID);
        void UpdateStudent(TEntity entity);
        void Save();
    }
}
