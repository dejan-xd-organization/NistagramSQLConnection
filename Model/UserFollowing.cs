namespace NistagramSQLConnection.Model
{
    public class UserFollowing
    {
        public long userId { get; set; }
        public User user { get; set; }

        public long followerId { get; set; }
        public Following following { get; set; }
    }
}
