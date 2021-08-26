using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NistagramSQLConnection.Model
{
    [Table("wallpost")]
    public class WallPost
    {
        [Key]
        public long id { get; set; }

        public DateTime timePublis { get; set; }

        public string imagePost { get; set; }

        public string postDescription { get; set; }

        public bool isPublic { get; set; }  // is wall post public or not?

        public ICollection<UserPost> userPosts { get; set; }

        public ICollection<PostReaction> postReactions { get; set; }

        public ICollection<PostComment> postComments { get; set; }
    }
}
