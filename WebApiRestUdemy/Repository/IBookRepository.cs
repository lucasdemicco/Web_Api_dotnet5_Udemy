using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestUdemy.Data.VO;

namespace WebApiRestUdemy.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookVO>> FindAllBooks();

        Task<BookVO> FindById(long id);
        Task<BookVO> Create(BookVO vo);
        Task<BookVO> Update(BookVO vo);
        Task<bool> Delete(long id);

    }
}
