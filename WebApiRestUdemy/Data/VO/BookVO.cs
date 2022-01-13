using System;
using System.Collections.Generic;
using WebApiRestUdemy.Hypermedia;
using WebApiRestUdemy.Hypermedia.Abstract;

namespace WebApiRestUdemy.Data.VO
{
    public class BookVO : ISupportHypermedia
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
