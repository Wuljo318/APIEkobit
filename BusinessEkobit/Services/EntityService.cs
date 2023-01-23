using BusinessEkobit.Interfaces;
using DataEkobit.Repositories;
using System.Linq.Expressions;


namespace BusinessEkobit.Services
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        protected readonly IAppDbBase<T> _appDbBase;
        public EntityService(IAppDbBase<T> appDbBase)
        {
            _appDbBase = appDbBase;
        }

        public IQueryable<T> GetAll()
        {
            return _appDbBase.FindAll();
        }
        public IQueryable<T> GetById(Expression<Func<T, bool>> expression)
        {
            return _appDbBase.FindUser(expression);
        }
        public void Add(T entity)
        {
            _appDbBase.Create(entity);
        }
        public void Update(T entity)
        {
            _appDbBase.Update(entity);
        }
        public void Delete(T entity)
        {
            _appDbBase.Update(entity);
        }
    }
}
