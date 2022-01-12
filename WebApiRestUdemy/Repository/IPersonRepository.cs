using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestUdemy.Data.VO;

namespace WebApiRestUdemy.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonVO>> FindAllPerson();
    }
}
