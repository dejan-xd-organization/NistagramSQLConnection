﻿namespace NistagramSQLConnection.Model
{
    public class UserPost
    {
        public long userId { get; set; }
        public User user { get; set; }


        public long postId { get; set; }
        public WallPost wallPost { get; set; }

    }
}
