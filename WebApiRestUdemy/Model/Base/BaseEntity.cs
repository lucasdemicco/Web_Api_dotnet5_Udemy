using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRestUdemy.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
