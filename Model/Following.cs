using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NistagramSQLConnection.Model
{
    [Table("following")]
    public class Following
    {
        [Key]
        public long id { get; set; }

        public DateTime dateOfFollowing { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }

        public ICollection<UserFollowing> userFollowings { get; set; }

    }
}
