using BusinessEkobit.Interfaces;
using DataEkobit.Entities;
using DataEkobit.Repositories;


namespace BusinessEkobit.Services
{
    public class UserService : EntityService<User>, IUserService
    {
        public UserService(IUserBase appDbBase)
            : base(appDbBase)
        {

        }


        public override async Task Add(User user)
        {
            _appDbBase.Create(user);
            await _appDbBase.Save();
        }

        public override async Task<List<User>> GetAll()
        {
            return await _appDbBase.FindAll();
        }
    }
}
