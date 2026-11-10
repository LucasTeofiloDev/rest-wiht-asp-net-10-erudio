using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Services.Interfaces;
using RestWithASPNET10.Data.DTO.V2;
using RestWithASPNET10.Services.Implementations.v2;
namespace RestWithASPNET10.Controllers.V2
{
    [Route("api/Person/v2")]
    [ApiController]
    public class PersonControllerV2 : ControllerBase
    {

        private PersonServicesV2 _personService;
        private readonly ILogger<PersonControllerV2> _logger;



        public PersonControllerV2(PersonServicesV2 personService, ILogger<PersonControllerV2> logger)
        {
            _personService = personService; 
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation($"Creating a new person: {person.FirstName}");
            var createdPerson = _personService.Create(person);
            if (createdPerson == null)
            {
                _logger.LogWarning($"Failed to create person: {person.FirstName}");
                return NotFound();
            }
            Response.Headers["X-API-Deprecated"] = "true";
            Response.Headers["X-API-Deprecated-Date"] = "2026-12-31";
            return Ok(createdPerson);
        }
    }
}
