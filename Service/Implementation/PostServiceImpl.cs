using Microsoft.EntityFrameworkCore;
using NistagramSQLConnection.Data;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NistagramSQLConnection.Service
{
    public class PostServiceImpl : IPostService
    {

        private readonly DataContext _db;

        public PostServiceImpl(DataContext db)
        {
            _db = db;
        }

        public List<WallPost> GetAllWallPosts(bool isPublic)
        {
            try
            {
                return _db.WallPosts.Where(x => x.isPublic == isPublic).Include(x => x.userPosts).Include(x => x.postReactions).ToList();
            }
            catch
            {
                return new List<WallPost>(0);
            }
        }

        public List<Reaction> GetAllReactions(List<long> id)
        {
            try
            {
                return _db.Reactions.Where(x => id.Contains(x.id)).ToList();
            }
            catch
            {
                return new List<Reaction>(0);
            }
        }

    }
}