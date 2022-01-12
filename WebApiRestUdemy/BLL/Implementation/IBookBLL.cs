using System.Collections.Generic;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.BLL.Implementation
{
    public interface IBookBLL
    {
        List<BookVO> FindAllBooks();

        BookVO FindById(long id);

        BookVO Create(BookVO book);

        BookVO Update(BookVO book);

        void Delete(long id);
    }
}
