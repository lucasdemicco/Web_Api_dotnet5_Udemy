using System;
using System.Collections.Generic;
using System.Linq;
using WebApiRestUdemy.Model;
using WebApiRestUdemy.Repository.Implementation;

namespace WebApiRestUdemy.BLL.Implementation
{
    public class PersonBLL : IPersonBLL
    {

        private readonly IRepository<Person> _repository;

        public PersonBLL(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
