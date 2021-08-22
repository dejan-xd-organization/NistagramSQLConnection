namespace NistagramSQLConnection.Model
{
    public class PostComment
    {
        public long postId { get; set; }
        public WallPost wallPost { get; set; }

        public long commentId { get; set; }
        public Comment comment { get; set; }
    }
}
