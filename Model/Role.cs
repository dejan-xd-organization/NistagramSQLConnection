using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
