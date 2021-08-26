using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NistagramSQLConnection.Model
{
    [Table("follower")]
    public class Follower
    {
        [Key]
        public long id { get; set; }

        public DateTime dateOfFollowing { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }

        public bool? accepted { get; set; }

        public ICollection<UserFollower> userFollowers { get; set; }
    }
}
