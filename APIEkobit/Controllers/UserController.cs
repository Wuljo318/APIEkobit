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
using AutoMapper.Execution;

namespace APIEkobit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, ICountryService countryService)
        {
            _userService = userService;
            _mapper = mapper;
            _countryService = countryService;
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
                //user.Country = await _countryService.GetById(_ => _.CountryId == user.CountryId); //baca null reffereance, a ne znam kaj bi tu bilo null
                //userDTO.CountryDTO = _mapper.Map<CountryDTO>(user.Country); 
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
                entity.Country = await _countryService.GetById(_ => _.CountryId == entity.CountryId);
                UserDTO userDTO = _mapper.Map<UserDTO>(entity);
                //userDTO.CountryDTO = _mapper.Map<CountryDTO>(entity.Country);
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
            //user.CountryId = user.Country.CountryId;   // ovo se ne dozvoljava - 'Object reference not set to an instance of an object.'
            //var country = await _countryService.GetById(_ => _.CountryId == user.Country.CountryId);
            //user.CountryId = userDTO.CountryDTO.CountryId;
            //user.Country = country;
            await _userService.Add(user); 
        }

        [HttpPut("update")]
        public async Task Update([FromBody] UserDTO userDTO)
        {
            long id = userDTO.UserId;
            var entity = await _userService.GetById(_ => _.UserId == id);
            //entity.Country = await _countryService.GetById(_ => _.CountryId == entity.CountryId);
            if (entity == null)
            {
                throw new EntityNotFoundException("Wrong user");
            }
            else
            {
                entity = _mapper.Map<User>(userDTO);
                //entity.Country = _mapper.Map<Country>(userDTO.CountryDTO);
                //entity.CountryId = entity.Country.CountryId;  //ovo se ne dozvoljava
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
