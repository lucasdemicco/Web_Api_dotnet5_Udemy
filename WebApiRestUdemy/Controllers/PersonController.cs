using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Hypermedia.Filters;
using WebApiRestUdemy.Repository;

namespace WebApiRestUdemy.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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

        /// <summary>
        /// Lista todos as pessoas
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Seleciona a pessoa pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adiciona uma nova pessoa
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualiza a pessoa selecionada
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Apaga a pessoa pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
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
