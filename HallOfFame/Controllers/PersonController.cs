using Microsoft.AspNetCore.Mvc;
using HallOfFame.Data;
using HallOfFame.Data.Transfer;

namespace HallOfFame.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository repo, ILogger<PersonController> logger)
        {
            _personRepository = repo;
            _logger = logger;
        }

        [HttpGet("persons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Person>> GetAll()
        {
            return await _personRepository.GetAllAsync();
        }

        [HttpGet("person/{id:long}", Name = "GetPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(long id)
        {
            var person = await _personRepository.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return new ObjectResult(person);
        }

        [HttpPost("person")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Person createdPerson)
        {
            if (createdPerson == null || createdPerson.Id != null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            createdPerson = await _personRepository.AddAsync(createdPerson);
            return CreatedAtRoute("GetPerson", new { id = createdPerson.Id }, createdPerson);
        }

        [HttpPut("person/{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(long id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (person == null || person.Id != null)
            {
                return BadRequest();
            }
            var foundPerson = await _personRepository.FindAsync(id);
            if (foundPerson == null)
            {
                return NotFound();
            }
            if (!(await _personRepository.UpdateAsync(id, person)))
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpDelete("person/{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long id)
        {
            var foundPerson = await _personRepository.FindAsync(id);
            if (foundPerson == null)
            {
                return NotFound();
            }
            if (!(await _personRepository.RemoveAsync(id)))
            {
                return NotFound();
            }
            return new NoContentResult();
        }

    }
}