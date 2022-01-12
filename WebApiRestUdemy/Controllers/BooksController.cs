using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;
using WebApiRestUdemy.Repository;

namespace WebApiRestUdemy.Controllers
{
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

        [HttpGet]
        public async Task<ActionResult<BookVO>> FindAllBooks()
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var books = await _repo.FindAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookVO>> FindById(long id)
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var book = await _repo.FindById(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookVO>> CreateBook(BookVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookCreate = await _repo.Create(vo);
            return Ok(bookCreate);
        }

        [HttpPut]
        public async Task<ActionResult<BookVO>> UpdateBook(BookVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookUpdate = await _repo.Update(vo);
            return Ok(bookUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(long id)
        {
            var status = await _repo.Delete(id);
            if (status is false) return StatusCode(404, "Books is not found!");

            return Ok(status);
        }
        [HttpGet]
        public async Task<ActionResult<BookVO>> FindAllBooks()
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var books = await _repo.FindAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookVO>> FindById(long id)
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            var book = await _repo.FindById(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookVO>> CreateBook(BookVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookCreate = await _repo.Create(vo);
            return Ok(bookCreate);
        }

        [HttpPut]
        public async Task<ActionResult<BookVO>> UpdateBook(BookVO vo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var bookCreate = await _repo.Update(vo);
            return Ok(bookCreate);
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


