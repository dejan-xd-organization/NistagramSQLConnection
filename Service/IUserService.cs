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
        User FindUserById(long id, List<bool> isPublicProfile);
        bool AddNewFollower(long myId, long followerId);
        User AddFollowing(long friendId, long myId);
        List<UserFollower> GetMyFollowers(string idUser, int page, int limit, bool accepted);
        List<UserFollowing> GetMyFollowing(string idUser, int page, int limit);
        List<UserFollower> GetNewFollowers(string idUser);
        List<UserFollowing> GetNewFollowings(string idUser);
        User UpdateUser(User user);
        bool ChangePassword(long id, string oldPassword, string newPassword);
    }
}
