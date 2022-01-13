using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Hypermedia.Filters;
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
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult<PersonVO>> FindAll()
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var persons = await _repo.FindAllPerson();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult<PersonVO>> FindPersonById(long id)
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var person = await _repo.FindById(id);
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType((201), Type = typeof(PersonVO))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult<PersonVO>> CreatePerson(PersonVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var personCreate = await _repo.Create(vo);
            return Ok(personCreate);
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult<PersonVO>> UpdatePerson(PersonVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var personUpdate = await _repo.Update(vo);
            return Ok(personUpdate);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((204), Type = typeof(PersonVO))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        public async Task<ActionResult> DeletePerson(long id)
        {
            var status = await _repo.Delete(id);
            if (status is false) return StatusCode(404, "Books is not found!");

            return Ok(status);
        }
    }
}
