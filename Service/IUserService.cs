using System.Collections.Generic;
using NistagramSQLConnection.Model;

namespace NistagramSQLConnection.Service.Interface
{
    public interface IUserService
    {
        List<User> FindUser(long id, string username, string email);
        User LoginUser(string username, string password);
        bool RegistrationUser(User user);
        List<User> FilterUser(string filter);
        List<User> FindNewUsers();
        User FindUserById(long id, bool isOnline);
        bool AddNewFollower(long myId, long followerId);
        List<UserFollower> GetFollowers(string id, int page, int limit, bool type);
        List<UserFollowing> GetNewFollowings(string idUser, int page, int limit);
    }
}
