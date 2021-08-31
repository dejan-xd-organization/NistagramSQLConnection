using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NistagramSQLConnection.Model
{
    [Table("message")]
    public class Message
    {
        [Key]
        public long id { get; set; }

        public string text { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }

    }
}
