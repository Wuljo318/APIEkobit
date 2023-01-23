using BusinessEkobit.Interfaces;
using BusinessEkobit.Services;
using DataEkobit.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace APIEkobit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; 

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IQueryable<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("getbyid/{id}")]
        public IQueryable<User> GetById([FromRoute] long id)
        {
            return _userService.GetById(_=>_.UserId==id);
        }


        [HttpPost("add")]
        public void Add([FromBody]User user)
        {       
            _userService.Add(user);
        }

        //[HttpPost]
        //public void Update(User user)
        //{
        //    _userService.Update(user);
        //}

        //[HttpDelete]
        //public void Delete(User user)
        //{
        //    _userService.Delete(user);
        //}

    }
}
