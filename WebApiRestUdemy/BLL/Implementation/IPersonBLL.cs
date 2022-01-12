using System.Collections.Generic;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.BLL.Implementation
{
    public interface IPersonBLL
    {
        List<Person> FindAll();

        Person FindById(long id);

        Person Create(Person person);

        Person Update(Person person);

        void Delete(long id);
    }
}
