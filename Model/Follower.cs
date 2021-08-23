using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NistagramSQLConnection.Model
{
    [Table("follower")]
    public class Follower
    {
        public long id { get; set; }
        public DateTime dateOfFollowing { get; set; }
        public User user { get; set; }
        public bool? accepted { get; set; }
    }
}
