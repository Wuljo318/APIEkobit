using DataEkobit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataEkobit.Repositories
{
    public interface IAppDbBase<T>
    {
        Task<T> FindById(Expression<Func<T, bool>> expression);
        Task<List<T>> FindAll();

        void Create (T entity);
        void Update (T entity);
        void Delete (T entity);
        Task Save();
    }
}
