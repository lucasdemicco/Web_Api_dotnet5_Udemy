using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiRestUdemy.Model.Base;

namespace WebApiRestUdemy.Model
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Column("user_name")]
        public string UserName { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("refresh_token")]
        public string RefreshToken { get; set; }

        [Column("refreshtoken_expirytype")]
        public DateTime RefreshTokenExpiryType { get; set; }
    }
}
