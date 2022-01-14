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
    [ApiController]
    [Route("/api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;
        public BooksController(IBookRepository repo)
        { 
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /// <summary>
        /// Obtém toda a lista de livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<BookVO>))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult<BookVO>> FindAll()
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var books = await _repo.FindAllBooks();
            return Ok(books);
        }

        /// <summary>
        /// Obtém um livo pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult<BookVO>> FindBookById(long id)
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var book = await _repo.FindById(id);
            return Ok(book);
        }

        /// <summary>
        /// Adiciona um novo registro
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(PersonVO))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult<BookVO>> CreateNewBook(BookVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookCreate = await _repo.Create(vo);
            return Ok(bookCreate);
        }

        /// <summary>
        /// Atualiza o registro selecionado
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult<BookVO>> UpdateABook(BookVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookUpdate = await _repo.Update(vo);
            return Ok(bookUpdate);
        }

        /// <summary>
        /// Apaga o registro pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((204), Type = typeof(PersonVO))]
        [ProducesResponseType((404))]
        [ProducesResponseType((500))]
        public async Task<ActionResult> DeleteABook(long id)
        {
            var status = await _repo.Delete(id);
            if (status is false) return StatusCode(404, "Books is not found!");

            return Ok(status);
        }
   
    }
}


