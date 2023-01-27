using BusinessEkobit.Exceptions;
using BusinessEkobit.Extensions;
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
        public override async Task Add(User user)
        {
            //try
            //{
                //user.Email.EmailCheck();
                //EmailValidationExtension.EmailCheck(user.Email);
                //EmailValidationExtension2.EmailCheck(user.Email);
                _appDbBase.Create(user);
                await _appDbBase.Save();
            //}
            //catch
            //{
            //    throw new EmailNotCorrectException("Email not correct!");
            //}
            
        }

        //public override Task<List<User>> GetAll()
        //{
        //    return _appDbBase.FindAll();
        //}
    }
}
