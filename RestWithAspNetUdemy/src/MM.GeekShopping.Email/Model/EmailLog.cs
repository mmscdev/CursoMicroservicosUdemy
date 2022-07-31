using MM.GeekShopping.Email.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.GeekShopping.Email.Model
{
    [Table("email_logs")]
    public class EmailLog : BaseEntity
    {
       
        [Column("email")]
        public string Email { get; set; }

        [Column("log")]
        public string Log { get; set; }

        [Column("sent_date")]
        public DateTime SentDate { get; set; }
    }
}
