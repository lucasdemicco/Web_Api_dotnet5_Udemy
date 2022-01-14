using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRestUdemy.Data;
using WebApiRestUdemy.Repository;

namespace UdemyApiTeste
{
    public class BooksUnitTestController
    {
        private IMapper _mapper;
        private BookRepository _repo;

        public BooksUnitTestController(IMapper mapper, BookRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public static DbContextOptions<DataContext> dbContextOptions { get; }

        public static string connectionString =
            "Server=localhost;Database=rest_api_net_udemy;Uid=root;Pwd=root";

        static BooksUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;
        }

        public BooksUnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Profile());
            });

            _mapper = config.CreateMapper();

            var context = new DataContext(dbContextOptions);

            _repo = new BookRepository(context);
        }
    }
}
