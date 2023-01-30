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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<List<CountryDTO>> GetAll()
        {
            List<Country> countries = await _countryService.GetAll();
            List<CountryDTO> countryDTOs = new();
            foreach (Country country in countries)
            {
                CountryDTO countryDTO = _mapper.Map<CountryDTO>(country);
                countryDTOs.Add(countryDTO);
            }
            return countryDTOs;
        }

        [HttpGet("getbyid /{id}")]
        public async Task<CountryDTO> GetById([FromRoute] long id)
        {
            try
            {
                var entity = await _countryService.GetById(_ => _.CountryId == id);
                CountryDTO countryDTO = _mapper.Map<CountryDTO>(entity);
                return countryDTO;
            }
            catch (Exception ex)
            {
                throw new EntryPointNotFoundException(ex.Message, ex);
            }
        }

        [HttpPost("add")]
        public async Task Add([FromBody] CountryDTO countryDTO)
        {
            Country country = _mapper.Map<Country>(countryDTO);
            await _countryService.Add(country);
        }

        [HttpPut("update")]
        public async Task Update([FromBody] CountryDTO countryDTO)
        {
            long id = countryDTO.CountryId;
            var entity = await _countryService.GetById(_ => _.CountryId == id);
            string shortName = entity.CountryCode;
            entity = _mapper.Map<Country>(countryDTO);
            entity.CountryCode = shortName;
            await _countryService.Update(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete([FromRoute] long id)
        {
            var entity = await _countryService.GetById(_ => _.CountryId == id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Wrong user");
            }
            else
            {
                await _countryService.Delete(entity);
            }
        }
    }
}
