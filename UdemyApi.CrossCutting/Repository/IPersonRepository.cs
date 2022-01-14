using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestUdemy.Data.VO;

namespace WebApiRestUdemy.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonVO>> FindAllPerson();

        Task<PersonVO> FindById(long id);
        Task<PersonVO> Create(PersonVO vo);
        Task<PersonVO> Update(PersonVO vo);
        Task<bool> Delete(long id);
    }
}
