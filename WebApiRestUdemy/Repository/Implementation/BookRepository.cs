using System;
using System.Collections.Generic;
using System.Linq;
using WebApiRestUdemy.Data;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {

        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public List<Book> FindAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return book;
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return new Book();
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            _context.Books.SingleOrDefault(b => b.Id.Equals(id));
            return true;
        }
    }
}
