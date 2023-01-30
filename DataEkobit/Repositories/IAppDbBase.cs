using System.Linq.Expressions;

namespace DataEkobit.Repositories
{
    public interface IAppDbBase<T>
    {
        Task<T> FindById(Expression<Func<T, bool>> expression);
        Task<List<T>> FindAll();

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task Save();
    }
}
