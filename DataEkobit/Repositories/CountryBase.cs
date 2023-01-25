using DataEkobit.Entities;
using DataEkobit.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEkobit.Repositories
{
    public class CountryBase : AppDbBase<Country>, ICountryBase
    {
        public CountryBase(AppDbContext appContext)
            :base(appContext)
        {

        }
    }
}
