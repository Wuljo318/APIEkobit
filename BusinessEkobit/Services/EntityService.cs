using BusinessEkobit.Exceptions;
using BusinessEkobit.Interfaces;
using DataEkobit.Repositories;
using System.Linq.Expressions;

namespace BusinessEkobit.Services
{
    public abstract class EntityService<T> : IEntityService<T> where T : class
    {
        protected readonly IAppDbBase<T> _appDbBase;
        public EntityService(IAppDbBase<T> appDbBase)
        {
            _appDbBase = appDbBase;
        }

        public virtual Task<List<T>> GetAll()
        {
            return _appDbBase.FindAll();
        }
        public async Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            var entity = await _appDbBase.FindById(expression);
            if (entity == null)
            {
                throw new EntityNotFoundException("Entitet nije pronaden");
            }
            else
            {
                return entity;
            }
        }

        public virtual async Task Add(T entity)
        {
            _appDbBase.Create(entity);
            await _appDbBase.Save();
        }

        public virtual async Task Update(T entity)
        {
            _appDbBase.Update(entity);
            await _appDbBase.Save();
        }

        public async Task Delete(T entity)
        {
            _appDbBase.Delete(entity);
            await _appDbBase.Save();
        }
    }
}
