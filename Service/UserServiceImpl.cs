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
    public class UserServiceImpl : IUserService
    {
        private readonly DataContext _db;

        public UserServiceImpl(DataContext db)
        {
            _db = db;
        }

        public List<User> FindUser(long id, string username = null, string email = null)
        {
            if (id == 0 && username == null && email == null)
            {
                return FindAll();
            }
            else
            {
                return new List<User>(0);
            }
        }

        private List<User> FindAll()
        {
            return _db.Users.OrderBy(i => i.username).ToList();
        }
    }
}
