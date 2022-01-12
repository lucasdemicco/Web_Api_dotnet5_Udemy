using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Repository;

namespace WebApiRestUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonRepository _repo;

        public PersonController(IPersonRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }


        [HttpGet]
        public async Task<ActionResult<PersonVO>> FindAllBooks()
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var persons = await _repo.FindAllPerson();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonVO>> FindById(long id)
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var person = await _repo.FindById(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<PersonVO>> CreateBook(PersonVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var personCreate = await _repo.Create(vo);
            return Ok(personCreate);
        }

        [HttpPut]
        public async Task<ActionResult<PersonVO>> UpdateBook(PersonVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var personUpdate = await _repo.Update(vo);
            return Ok(personUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(long id)
        {
            var status = await _repo.Delete(id);
            if (status is false) return StatusCode(404, "Books is not found!");

            return Ok(status);
        }
    }
}
