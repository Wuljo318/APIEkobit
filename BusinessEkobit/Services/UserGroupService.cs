using BusinessEkobit.Interfaces;
using DataEkobit.Entities;
using DataEkobit.Repositories;


namespace BusinessEkobit.Services
{
    public class UserGroupService : EntityService<UserGroup>, IUserGroupService
    {
        public UserGroupService(IUserGroupBase appDbBase)
            : base(appDbBase)
        {

        }
    }
}
