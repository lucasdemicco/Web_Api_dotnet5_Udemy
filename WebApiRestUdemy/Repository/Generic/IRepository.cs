﻿using System.Collections.Generic;
using WebApiRestUdemy.Model;
using WebApiRestUdemy.Model.Base;

namespace WebApiRestUdemy.Repository.Implementation
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> FindAll();

        T FindById(long id);

        T Create(T item);

        T Update(T item);

        void Delete(long id);

        bool Exists(long id);
    }
}
