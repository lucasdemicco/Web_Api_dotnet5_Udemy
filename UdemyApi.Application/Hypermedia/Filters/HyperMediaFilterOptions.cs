using System.Collections.Generic;
using WebApiRestUdemy.Hypermedia.Abstract;

namespace WebApiRestUdemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
