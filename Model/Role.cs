using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NistagramSQLConnection.Model
{
    [Table("role")]
    public class Role
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
    }
}
