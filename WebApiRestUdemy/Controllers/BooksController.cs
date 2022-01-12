using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiRestUdemy.Model;
using WebApiRestUdemy.Repository.Generic;
using WebApiRestUdemy.Repository.Implementation;

namespace WebApiRestUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("/api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repository;
        public BooksController(IRepository<Book> repository)
        { 
            _repository = repository;
        }

        [HttpGet]
        public IActionResult FindAllBooks()
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            return Ok(_repository.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            return Ok(_repository.FindById(id));
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_repository.Create(book));
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_repository.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(long id)
        {
            if (!ModelState.IsValid) return StatusCode(404, "Books is not found!");

            _repository.Delete(id);

            return NoContent();
        }
    }
}


