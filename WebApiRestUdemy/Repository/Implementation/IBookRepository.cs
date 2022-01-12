using System.Collections.Generic;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Repository.Implementation
{
    public interface IBookRepository
    {
        List<Book> FindAllBooks();

        Book FindById(long id);

        Book Create(Book book);

        Book Update(Book book);

        void Delete(long id);

        bool Exists(long id);
    }
}
