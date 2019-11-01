using System.Threading.Tasks;
using Activities.DTO;
using Activities.Logic.DataModel;
using Activities.Logic.Exceptions;
using Activities.Logic.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Activities.API.Controllers
{
    [Route("person")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDto personDto)
        {
            Person person = _mapper.Map<Person>(personDto);

            if (person == null)
            {
                return BadRequest();
            }

            try
            {
                await _personService.AddPerson(person);
            }
            catch (InvalidPersonException)
            {
                return BadRequest();
            }

            return Accepted();
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var results = await _personService.GetPeople();

            return Ok(results);
        }
    }
}