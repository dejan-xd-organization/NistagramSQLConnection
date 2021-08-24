namespace NistagramSQLConnection.Model
{
    public class UserFollower
    {
        public long userId { get; set; }
        public User user { get; set; }

        public long followerId { get; set; }
        public Follower follower { get; set; }

    }
}
