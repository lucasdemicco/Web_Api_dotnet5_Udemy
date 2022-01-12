using System.Collections.Generic;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.BLL.Implementation
{
    public interface IPersonBLL
    {
        List<PersonVO> FindAll();

        PersonVO FindById(long id);

        PersonVO Create(PersonVO person);

        PersonVO Update(PersonVO person);

        void Delete(long id);
    }
}
