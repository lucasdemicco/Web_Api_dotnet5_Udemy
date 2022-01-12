using System.Collections.Generic;

namespace WebApiRestUdemy.Data.Converter.Contratc
{
    public interface IParser<D, O>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
