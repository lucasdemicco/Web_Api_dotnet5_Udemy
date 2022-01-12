
using Microsoft.EntityFrameworkCore;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
