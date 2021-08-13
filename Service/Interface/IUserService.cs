using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NistagramSQLConnection.Model;

namespace NistagramSQLConnection.Service.Interface
{
    public interface IUserService
    {
        List<User> FindUser(long id, string username, string email);
    }
}
