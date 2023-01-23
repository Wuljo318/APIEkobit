using DataEkobit.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataEkobit.Repositories
{
    public class AppDbBase<T> : IAppDbBase<T> where T : class
    {
        public AppDbContext appDbContext { get; set; }

        public AppDbBase(AppDbContext appDC)
        {
            appDbContext = appDC;
        }

        public async Task<List<T>> FindAll()                          //koji tip koristit ako ne dozvoljava List
        {
            return await appDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> FindById(Expression<Func<T, bool>>expression)
        {
            var entity = await appDbContext.Set<T>().Where(expression).FirstOrDefaultAsync();
            return entity;
        }

        public void Create(T entity)
        {
            appDbContext.Set<T>().Add(entity);                  //ne dozvoljava da se stavi await
        }

        public void Update(T entity)
        {
            appDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            appDbContext.Set<T>().Remove(entity);   
        }

        public async Task Save()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
