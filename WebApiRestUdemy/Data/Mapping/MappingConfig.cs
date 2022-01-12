﻿using AutoMapper;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Data.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonVO, Person>();
                config.CreateMap<Person, PersonVO>();

                config.CreateMap<BookVO, Book>();
                config.CreateMap<Book, BookVO>();
            });

            return mappingConfig;
        }
    }
}
