using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiRestUdemy.Model;
using WebApiRestUdemy.Repository.Implementation;

namespace WebApiRestUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("/api/[controller]/v{version:apiVesion}")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;
        public BooksController(IBookRepository repository)
        { 
            _repository = repository;
        }

        [HttpGet]
        public IActionResult FindAllBooks()
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            return Ok(_repository.FindAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            if (!ModelState.IsValid)
                return StatusCode(404, "Books not found!");

            return Ok(_repository.FindById(id));
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_repository.Create(book));
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_repository.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repository.Delete(id);

            return NoContent();
        }
    }
}


