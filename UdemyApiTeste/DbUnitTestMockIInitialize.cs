using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApi.Domain.Model;
using WebApiRestUdemy.Data;

namespace UdemyApiTeste
{
    public class DbUnitTestMockIInitialize
    {
        public DbUnitTestMockIInitialize()
        {

        }

        public void Seed(DataContext context)
        {
            context.Books.Add
                (new Book { Id = 1, Author = "Mauricio de Souza", LaunchDate = DateTime.Now, Price = 19, Title = "Turma da Mônica" });

            context.Books.Add
                (new Book { Id = 2, Author = "J.R.R Tolkien", LaunchDate = DateTime.Now, Price = 99, Title = "O Senhor dos Anéis" });
        }
    }
}
