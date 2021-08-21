using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NistagramSQLConnection.Data;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;

namespace NistagramSQLConnection.Service
{
    public class PostServiceImpl : IPostService
    {

        private readonly DataContext _db;

        public PostServiceImpl(DataContext db)
        {
            _db = db;
        }

        public List<WallPost> GetAllWallPosts(bool isPublic = false)
        {
            try
            {
                return _db.WallPosts.Where(x => x.isPublic == isPublic).ToList();
            }
            catch (Exception e)
            {
                return new List<WallPost>(0);
            }
        }
    }
}
