using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
