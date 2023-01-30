using DataEkobit.Entities;
using DataEkobit.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEkobit.Services
{
    public class UserGroupService : EntityService<UserGroup>
    {
        public UserGroupService(IAppDbBase<UserGroup> appDbBase)
            : base(appDbBase)
        {

        }
    }
}
