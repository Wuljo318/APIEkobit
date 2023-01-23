using DataEkobit.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public IQueryable<T> FindAll()
        {
            return appDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindUser(Expression<Func<T, bool>>expression)
        {
            return appDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            appDbContext.Set<T>().Add(entity);
            //appDbContext.Database.ExecuteSqlCommand("SET IDENTITIY_INSERT ")
            appDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            appDbContext.Set<T>().Update(entity);
            appDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            appDbContext.Set<T>().Remove(entity);
            appDbContext.SaveChanges();
        }
    }
}
