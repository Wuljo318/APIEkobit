using DataEkobit.Context;
using DataEkobit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEkobit.Repositories
{
    public class UserGroupBase : AppDbBase<UserGroup>, IUserGroupBase
    {
        public UserGroupBase(AppDbContext appDbContext)
            :base(appDbContext)
        {

        }
    }
}
