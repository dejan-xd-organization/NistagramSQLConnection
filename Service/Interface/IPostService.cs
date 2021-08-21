using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NistagramSQLConnection.Model;

namespace NistagramSQLConnection.Service.Interface
{
    public interface IPostService
    {

        List<WallPost> GetAllWallPosts(bool isPublic);
    }
}
