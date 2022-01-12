using System.Collections.Generic;
using System.Linq;
using WebApiRestUdemy.Data.Converter.Contratc;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public PersonVO Parse(Person origin)
        {
            if (origin is null) return null;

            return new PersonVO
            { 
                Id = origin.Id,
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName
            };
        }
        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }


        public Person Parse(PersonVO origin)
        {
            if (origin is null) return null;

            return new Person
            {
                Id = origin.Id,
                Address = origin.Address,
                FirstName = origin.FirstName,
                Gender = origin.Gender,
                LastName = origin.LastName
            };
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
