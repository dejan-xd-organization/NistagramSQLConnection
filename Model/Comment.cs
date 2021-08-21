using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NistagramSQLConnection.Model
{
    [Table("comment")]
    public class Comment
    {

        [Key]
        public long id { get; set; }

        public string comment { get; set; }

        public DateTime? timeDateComments { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }

        [ForeignKey("commentId")]
        public virtual ICollection<PostComment> postComments { get; set; }
    }
}
