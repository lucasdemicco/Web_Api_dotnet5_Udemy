using System.Collections.Generic;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Services.Implementation
{
    public interface IPersonService
    {
        List<Person> FindAll();

        Person FindById(long id);

        Person Create(Person person);

        Person Update(Person person);

        void Delete(long id);
    }
}
