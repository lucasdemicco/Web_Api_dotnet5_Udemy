using Microsoft.AspNetCore.Mvc;
using WebApiRestUdemy.BLL.Implementation;
using WebApiRestUdemy.Model;
using WebApiRestUdemy.Repository.Implementation;

namespace WebApiRestUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IRepository<Person> _person;

        public PersonController(IRepository<Person> person)
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
