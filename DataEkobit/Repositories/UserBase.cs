using DataEkobit.Context;
using DataEkobit.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataEkobit.Repositories
{
    public class UserBase : AppDbBase<User>, IUserBase
    {
        public UserBase(AppDbContext appDC)
            : base(appDC)
        {
        }

        public override async Task<List<User>> FindAll()
        {
            return await _appDbContext.Set<User>()
                .Include(u => u.Country)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<User> FindById(Expression<Func<User, bool>> expression)
        {
            return await _appDbContext.Set<User>()
                .Where(expression)
                .Include(u => u.Country)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
