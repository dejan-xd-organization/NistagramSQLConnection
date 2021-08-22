using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NistagramSQLConnection.Model
{
    [Table("reaction")]
    public class Reaction
    {
        [Key]
        public long id { get; set; }

        public bool? type { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }

        [ForeignKey("reactionId")]
        public virtual ICollection<PostReaction> postReactions { get; set; }
    }
}
