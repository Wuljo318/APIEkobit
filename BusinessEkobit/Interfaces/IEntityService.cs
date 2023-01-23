using System.Linq.Expressions;


namespace BusinessEkobit.Interfaces
{
    public interface IEntityService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
