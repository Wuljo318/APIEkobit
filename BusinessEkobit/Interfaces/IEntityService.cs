using System.Linq.Expressions;


namespace BusinessEkobit.Interfaces
{
    public interface IEntityService<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetById(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
