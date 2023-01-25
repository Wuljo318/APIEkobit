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
    public class CountryService : EntityService<Country>, ICountryService
    {
        public CountryService(IAppDbBase<Country> appDbBase) 
            : base(appDbBase)
        {

        }
    }
}
