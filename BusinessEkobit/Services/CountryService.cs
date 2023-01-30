using BusinessEkobit.Interfaces;
using DataEkobit.Entities;
using DataEkobit.Repositories;

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
