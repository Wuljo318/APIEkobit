using BusinessEkobit.Interfaces;
using BusinessEkobit.Exceptions;
using BusinessEkobit.Models;
using BusinessEkobit.Automaper;
using BusinessEkobit.Services;
using DataEkobit.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Collections.Generic;
using AutoMapper;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Identity.Client;

namespace APIEkobit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<List<UserDTO>> GetAll()
        {    
            List<User> users = await _userService.GetAll();
            //List<UserDTO> usersDTO = _mapper.Map<List<User>, List<UserDTO>> (users);     //prvi način
            List<UserDTO> usersDTO = new List<UserDTO>();                                  //drugi način
            foreach (User user in users)
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                usersDTO.Add(userDTO);                             
            }
            return usersDTO;
        }
            
        [HttpGet("getbyid/{id}")]
        public async Task<UserDTO> GetById([FromRoute] long id)
        {
            //mozda bi radi optimizacija koda bilo bolje da se tu makne try catch jer u Entity serviceu postoji bacanje errora
            try
            {
                var entity = await _userService.GetById(_ => _.UserId == id);
                UserDTO userDTO = _mapper.Map<UserDTO>(entity);
                return userDTO;
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException(ex.Message, ex);
            }

        }

        [HttpPost("add")]
        public async Task Add([FromBody]UserDTO userDTO)
        {
                User user = _mapper.Map<User>(userDTO);
                await _userService.Add(user); //moguce da je neki problem sa spremanjem u bazu jer sve prode dobro i onda se kod debuganja zaustavi na spremanju
        }

        [HttpPut("update/{id}")]
        public async Task Update([FromBody] UserDTO userDTO, [FromRoute]long id)
        {
            var entity = await _userService.GetById(_ => _.UserId == id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Wrong user");
            }
            else
            {
                entity = _mapper.Map<User>(userDTO);
                //kak napraviti mapiranje, a da se promijene samo određeni atributi
                await _userService.Update(entity);
            }

        }

        [HttpDelete("delete/{id}")]
        public async Task Delete([FromRoute] long id)                    
        {
            var entity = await _userService.GetById(_ => _.UserId == id); 
            if(entity == null)
            {
                throw new EntityNotFoundException("Wrong user");
            }
            else
            {
                await _userService.Delete(entity);
            }
            
        }

    }
}
