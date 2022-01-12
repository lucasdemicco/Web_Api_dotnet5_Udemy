using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestUdemy.Data;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookVO>> FindAllBooks()
        {
            List<Book> books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookVO>>(books);
        }

        public async Task<BookVO> FindById(long id)
        {
            Book book = await _context.Books.SingleOrDefaultAsync(x => x.Id .Equals(id));
            return _mapper.Map<BookVO>(book);
        }


        public async Task<BookVO> Create(BookVO vo)
        {
            Book book = _mapper.Map<Book>(vo);
            _context.Add(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookVO>(book);
        }

        public async Task<BookVO> Update(BookVO vo)
        {
            Book book = _mapper.Map<Book>(vo);
            _context.Update(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookVO>(book);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (book == null) return false;

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
