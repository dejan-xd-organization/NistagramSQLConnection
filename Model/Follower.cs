using System;
using System.ComponentModel.DataAnnotations.Schema;

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
