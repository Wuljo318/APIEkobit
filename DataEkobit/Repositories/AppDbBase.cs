using DataEkobit.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataEkobit.Repositories
{
    public class AppDbBase<T> : IAppDbBase<T> where T : class
    {
        protected readonly AppDbContext _appDbContext;

        public AppDbBase(AppDbContext appDC)
        {
            _appDbContext = appDC;
        }

        public virtual async Task<List<T>> FindAll()
        {
            return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> FindById(Expression<Func<T, bool>> expression)
        {
            var entity = await _appDbContext.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
            return entity;
        }

        public void Create(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
