using BusinessEkobit.Interfaces;
using DataEkobit.Entities;
using DataEkobit.Repositories;

namespace BusinessEkobit.Services
{
    public class GroupService : EntityService<Group>, IGroupService
    {
        public GroupService(IAppDbBase<Group> appDbBase)
            : base(appDbBase)
        {

        }
    }
}
