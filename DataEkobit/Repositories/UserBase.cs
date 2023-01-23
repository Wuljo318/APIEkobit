using DataEkobit.Context;
using DataEkobit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEkobit.Repositories
{
    public class UserBase : AppDbBase<User>, IUserBase
    {
        public UserBase(AppDbContext appDC) 
            : base(appDC)
        {
        }
    }
}
