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
                if (isPublic != true) isPublic = false;
                return _db.WallPosts.Where(x => x.isPublic == isPublic).ToList();
            }
            catch
            {
                return new List<WallPost>(0);
            }
        }
    }
}
