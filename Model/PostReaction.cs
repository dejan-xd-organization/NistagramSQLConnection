using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NistagramSQLConnection.Model
{
    public class PostReaction
    {
        public long postId { get; set; }
        public WallPost wallPost { get; set; }

        public long reactionId { get; set; }
        public Reaction reaction { get; set; }

    }
}
