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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GroupDTO>> GetAll()
        {
            List<Group> groups = await _groupService.GetAll();
            List<GroupDTO> groupDTOs = new List<GroupDTO>();
            foreach(Group group in groups)
            {
                GroupDTO groupDTO = _mapper.Map<GroupDTO>(group);
                groupDTOs.Add(groupDTO);
            }
            return groupDTOs;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<GroupDTO> GetById([FromRoute] long id)
        {
            try
            {
                var entity = await _groupService.GetById(_ => _.GroupId == id);
                GroupDTO GroupDTO = _mapper.Map<GroupDTO>(entity);
                return GroupDTO;
            }
            catch(Exception ex)
            {
                throw new EntityNotFoundException(ex.Message, ex);
            }
        }

        [HttpPost("add")]
        public async Task Add([FromBody] GroupDTO groupDTO)
        {
            Group group = _mapper.Map<Group>(groupDTO);
            await _groupService.Add(group);
        }

        [HttpPut("update")]
        public async Task Update([FromBody] GroupDTO groupDTO)
        {
            long id = groupDTO.GroupId;
            var entity = await _groupService.GetById(_ => _.GroupId == id);
            if(entity == null)
            {
                throw new EntityNotFoundException("Wrong group");
            }
            else
            {
                entity = _mapper.Map<Group>(groupDTO);
                await _groupService.Update(entity);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete([FromRoute] long id)
        {
            var entity = await _groupService.GetById(_ => _.GroupId == id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Wrong group");
            }
            else
            {
                await _groupService.Delete(entity);
            }
        }
    }
}
