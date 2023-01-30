using DataEkobit.Context;
using DataEkobit.Entities;

namespace DataEkobit.Repositories
{
    public class CountryBase : AppDbBase<Country>, ICountryBase
    {
        public CountryBase(AppDbContext appContext)
            : base(appContext)
        {

        }
    }
}
