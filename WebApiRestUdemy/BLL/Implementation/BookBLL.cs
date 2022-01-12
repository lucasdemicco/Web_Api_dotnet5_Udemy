using System.Collections.Generic;
using WebApiRestUdemy.Model;
using WebApiRestUdemy.Repository.Implementation;

namespace WebApiRestUdemy.BLL.Implementation
{
    public class BookBLL : IBookBLL
    {

        private readonly IBookRepository _repository;

        public BookBLL(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> FindAllBooks()
        {
            return _repository.FindAllBooks();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
