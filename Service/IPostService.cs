using System.Collections.Generic;
using NistagramSQLConnection.Model;

namespace NistagramSQLConnection.Service.Interface
{
    public interface IPostService
    {

        List<WallPost> GetAllWallPosts(List<bool> isPublic, int page, int limit);
        List<Reaction> GetAllReactions(List<long> id);
        bool PutReaction(long id, bool type, long userId);
        WallPost NewPost(long userId, string description, string imgLink, bool isPublic);
        List<UserPost> GetMyWallPosts(long id, int page, int limit);
    }
}
