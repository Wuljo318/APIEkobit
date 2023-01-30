using BusinessEkobit.Interfaces;
using DataEkobit.Entities;
using DataEkobit.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEkobit.Services
{
    public class GroupService : EntityService<Group>, IGroupService
    {
        public GroupService(IAppDbBase<Group> appDbBase)
            :base(appDbBase)
        {

        }
    }
}
