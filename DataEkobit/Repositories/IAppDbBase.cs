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
        IQueryable<T> FindUser(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAll();

        void Create (T entity);
        void Update (T entity);
        void Delete (T entity);
    }
}
