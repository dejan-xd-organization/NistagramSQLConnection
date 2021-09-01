using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
