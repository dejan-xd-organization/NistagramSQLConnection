using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NistagramSQLConnection.Model
{
    public class UserFollowing
    {
        public long userId { get; set; }
        public User user { get; set; }

        public long followerId { get; set; }
        public Follower follower { get; set; }
    }
}
