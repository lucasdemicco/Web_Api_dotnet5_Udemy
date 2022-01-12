﻿using System.Collections.Generic;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Repository.Implementation
{
    public interface IPersonRepository
    {
        List<Person> FindAll();

        Person FindById(long id);

        Person Create(Person person);

        Person Update(Person person);

        void Delete(long id);

        bool Exists(long id);
    }
}
