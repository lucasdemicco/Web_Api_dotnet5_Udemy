using System.Collections.Generic;

namespace WebApiRestUdemy.Hypermedia.Abstract
{
    public interface ISupportHypermedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
