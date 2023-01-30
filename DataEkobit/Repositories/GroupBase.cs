using DataEkobit.Context;
using DataEkobit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEkobit.Repositories
{
    public class GroupBase : AppDbBase<Group>, IGroupBase
    {
        public GroupBase(AppDbContext appDbContext)
            :base(appDbContext)
        { 

        }

    }
}
