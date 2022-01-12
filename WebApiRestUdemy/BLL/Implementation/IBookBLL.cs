using System.Collections.Generic;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.BLL.Implementation
{
    public interface IBookBLL
    {
        List<Book> FindAllBooks();

        Book FindById(long id);

        Book Create(Book book);

        Book Update(Book book);

        void Delete(long id);
    }
}
