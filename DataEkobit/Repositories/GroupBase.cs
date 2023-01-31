using DataEkobit.Context;
using DataEkobit.Entities;

namespace DataEkobit.Repositories
{
    public class GroupBase : AppDbBase<Group>, IGroupBase
    {
        public GroupBase(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }

    }
}
