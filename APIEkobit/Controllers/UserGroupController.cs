using AutoMapper;
using BusinessEkobit.Exceptions;
using BusinessEkobit.Interfaces;
using BusinessEkobit.Models;
using DataEkobit.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIEkobit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupService _userGroupService;
        private readonly IMapper _mapper;

        public UserGroupController(IUserGroupService userGroupService, IMapper mapper)
        {
            _userGroupService = userGroupService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<List<UserGroupDTO>> GetAll()
        {
            List<UserGroup> userGroups = await _userGroupService.GetAll();
            List<UserGroupDTO> userGroupDTOs = new List<UserGroupDTO>();
            foreach (UserGroup userGroup in userGroups)
            {
                UserGroupDTO userGroupDTO = _mapper.Map<UserGroupDTO>(userGroup);
                userGroupDTOs.Add(userGroupDTO);
            }
            return userGroupDTOs;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<UserGroupDTO> GetById([FromRoute] long id)
        {
            try
            {
                var entity = await _userGroupService.GetById(_ => _.UserGroupId == id);
                UserGroupDTO userGroupDTO = _mapper.Map<UserGroupDTO>(entity);
                return userGroupDTO;
            }
            catch (Exception ex)
            {
                throw new EntryPointNotFoundException(ex.Message, ex);
            }
        }

        [HttpPost("add")]
        public async Task Add([FromBody] UserGroupDTO userGroupDTO)
        {
            UserGroup userGroup = _mapper.Map<UserGroup>(userGroupDTO);
            await _userGroupService.Add(userGroup);
        }

        [HttpPut("update")]
        public async Task Update([FromBody] UserGroupDTO userGroupDTO)
        {
            long id = userGroupDTO.UserGroupId;
            var entity = await _userGroupService.GetById(_ => _.UserGroupId == id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Wrong UserGroup");
            }
            else
            {
                entity = _mapper.Map<UserGroup>(userGroupDTO);
                await _userGroupService.Update(entity);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete([FromRoute] long id)
        {
            var entity = await _userGroupService.GetById(_ => _.UserGroupId == id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Wrong UserGroup");
            }
            else
            {
                await _userGroupService.Delete(entity);
            }
        }
    }
}
