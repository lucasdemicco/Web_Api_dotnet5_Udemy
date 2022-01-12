using System.Collections.Generic;
using System.Linq;
using WebApiRestUdemy.Data.Converter.Contratc;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin is null) return null;

            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public Book Parse(BookVO origin)
        {
            if (origin is null) return null;

            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
