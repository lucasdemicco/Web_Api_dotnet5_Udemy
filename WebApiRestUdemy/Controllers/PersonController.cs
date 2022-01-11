using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRestUdemy.Model;
using WebApiRestUdemy.Services.Implementation;

namespace WebApiRestUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _person;

        public PersonController(IPersonService person)
        {
            _person = person;
        }

        [HttpGet]
        public IActionResult GetAllPerson()
        {
            if (!ModelState.IsValid) return StatusCode(404, "Person is not found!");

            return Ok(_person.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(long id)
        {
            if (!ModelState.IsValid) return StatusCode(404, "Person is not found!");

            return Ok(_person.FindById(id));
        }

        [HttpPost]
        public IActionResult CreateNewPerson(Person person)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_person.Create(person));
        }

        [HttpPut]
        public IActionResult UpdatePerson(Person person)
        {
            if (person is null) return BadRequest();

            return Ok(_person.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            if (!ModelState.IsValid) return StatusCode(404, "Person is not found!");

            _person.Delete(id);

            return NoContent();
        }
    }
}
