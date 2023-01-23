using BusinessEkobit.Interfaces;
using BusinessEkobit.Models;
using DataEkobit.Entities;
using DataEkobit.Repositories;


namespace BusinessEkobit.Services
{
    public class UserService : EntityService<User>, IUserService
    {
        public UserService(IAppDbBase<User> appDbBase) : base(appDbBase)
        {
        }
    }
}
