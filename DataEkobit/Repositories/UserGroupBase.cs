using DataEkobit.Context;
using DataEkobit.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataEkobit.Repositories
{
    public class UserGroupBase : AppDbBase<UserGroup>, IUserGroupBase
    {
        public UserGroupBase(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }

        public override async Task<List<UserGroup>> FindAll()
        {
            return await _appDbContext.Set<UserGroup>()
                .Include(ug => ug.Group)
                .Include(ug => ug.User)
                .Include(ug => ug.User.Country)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<UserGroup> FindById(Expression<Func<UserGroup, bool>> expression)
        {
            return await _appDbContext.Set<UserGroup>()
                .Where(expression)
                .Include(ug => ug.Group)
                .Include(ug => ug.User)
                .Include(ug => ug.User.Country)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
