using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services.Interfaces;

namespace RestWithASPNET10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IPersonServices _personService;
        private readonly ILogger<PersonController> _logger;



        public PersonController(IPersonServices personService, ILogger<PersonController> logger)
        {
            _personService = personService; 
            _logger = logger;
        }

        [HttpGet]

        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all persons");
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation($"Fetching person with ID: {id}");
            var person = _personService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning($"Person with ID: {id} not found");
                return NotFound();
            }
            return Ok(person);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation($"Creating a new person: {person.FirstName}");
            var createdPerson = _personService.Create(person);
            if (createdPerson == null)
            {
                _logger.LogWarning($"Failed to create person: {person.FirstName}");
                return NotFound();
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            _logger.LogInformation($"Updating person with ID: {person.Id}");
            var updatePerson = _personService.Update(person);
            if (updatePerson == null)
            {
                _logger.LogError($"Failed to update person with ID: {person.Id}");
                return NotFound();
            }
            _logger.LogDebug($"Person with ID: {person.Id} updated successfully");
            return Ok(updatePerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Deleting person with ID: {id}");
            _personService.Delete(id);
            _logger.LogDebug($"Person with ID: {id} deleted successfully");
            return NoContent();
        }
    }
}
