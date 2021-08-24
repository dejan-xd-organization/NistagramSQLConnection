using NistagramSQLConnection.Model;
using System.Collections.Generic;

namespace NistagramSQLConnection.Service.Interface
{
    public interface IPostService
    {

        List<WallPost> GetAllWallPosts(bool isPublic);
        List<Reaction> GetAllReactions(List<long> id);
    }
}
