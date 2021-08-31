using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NistagramSQLConnection.Data;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using Scrypt;

namespace NistagramSQLConnection.Service
{
    public class UserServiceImpl : IUserService
    {
        private readonly DataContext _db;
        readonly ScryptEncoder encoder = new ScryptEncoder();

        public UserServiceImpl(DataContext db)
        {
            _db = db;
        }

        public List<User> FindUser(long id, string username, string email)
        {
            if (username == "") username = null;
            if (email == "") email = null;
            if (id == 0 && username == null && email == null)
            {
                return FindAll();
            }
            else
            {
                return new List<User>(0);
            }
        }

        public User LoginUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            try
            {
                User user = _db.Users
                    .Where(x => x.username == username)
                    .Include(x => x.userFollowers)
                    .Include(x => x.userFollowings)
                    .Include(x => x.address)
                    .SingleOrDefault();

                if (user == null) return null;
                if (!encoder.Compare(password, user.password)) return null;
                return user;
            }
            catch
            {
                return null;
            }
        }

        public bool RegistrationUser(User user)
        {
            User newUser = new User();
            newUser.firstName = user.firstName;
            newUser.lastName = user.lastName;
            newUser.username = user.username;
            newUser.email = user.email;
            newUser.sex = user.sex;
            newUser.dateOfBirth = user.dateOfBirth;
            newUser.dateOfRegistration = user.dateOfRegistration;

            newUser.password = encoder.Encode(user.password);
            try
            {
                _db.Users.Add(newUser);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> FilterUser(string filter)
        {
            try
            {
                return _db.Users.Where(x => x.firstName.Contains(filter) || x.lastName.Contains(filter)
                || x.email.Contains(filter) || x.username.Contains(filter)).ToList();
            }
            catch
            {
                return new List<User>(0);
            }
        }

        public List<User> FindNewUsers()
        {
            try
            {
                return _db.Users.OrderByDescending(x => x.dateOfRegistration).Take(5).ToList();
            }
            catch
            {
                return new List<User>(0);
            }
        }

        public User FindUserById(long id, bool isOnline)
        {
            try
            {
                User user = _db.Users
                    .Where(x => x.isPublicProfile == isOnline)
                    .Where(x => x.id == id)
                    .FirstOrDefault();

                return user;
            }
            catch
            {
                return new User();
            }
        }


        private List<User> FindAll()
        {
            return _db.Users.OrderBy(i => i.username).ToList();
        }

        public bool AddNewFollower(long myId, long followerId)
        {
            UserFollower uf = _db.UserFollowers.FirstOrDefault(x => x.userId == myId && x.follower.user.id == followerId);

            if (uf == null)
            {
                User user = _db.Users.FirstOrDefault(x => x.id == followerId);
                if (user == null)
                {
                    return false;
                }

                User myself = _db.Users.Where(x => x.id == myId).Include(uf => uf.userFollowers).FirstOrDefault();

                Follower newFollower = new Follower();
                newFollower.dateOfFollowing = DateTime.Now;
                newFollower.user = user;
                _db.Followers.Add(newFollower);
                _db.SaveChanges();

                UserFollower newUf = new UserFollower();
                newUf.user = myself;
                newUf.userId = myself.id;
                newUf.follower = newFollower;
                newUf.followerId = newFollower.user.id;
                _db.SaveChanges();

                myself.userFollowers.Add(newUf);
                _db.SaveChanges();

                return true;
            }
            else
            {
                uf.follower.dateOfFollowing = DateTime.Now;
                _db.SaveChanges();
                return true;

            }
        }

        public List<UserFollower> GetMyFollowers(string idUser, int page, int limit, bool accepted)
        {
            if (page == 0) page = 1;
            if (limit == 0) limit = 20;
            var skip = (page - 1) * limit;

            try
            {
                List<UserFollower> user = _db.UserFollowers
                    .Where(x => x.userId == long.Parse(idUser) && x.follower.accepted == accepted)
                    .Skip(skip)
                    .Take(limit)
                    .Include(x => x.follower.user)
                    .ToList();

                return user;
            }
            catch
            {
                return new List<UserFollower>(0);
            }

        }

        public List<UserFollowing> GetMyFollowing(string idUser, int page, int limit)
        {
            if (page == 0) page = 1;
            if (limit == 0) limit = 20;
            var skip = (page - 1) * limit;

            try
            {
                List<UserFollowing> user = _db.UserFollowings
                    .Where(x => x.userId == long.Parse(idUser))
                    .Skip(skip)
                    .Take(limit)
                    .Include(x => x.following.user)
                    .ToList();

                return user;
            }
            catch
            {
                return new List<UserFollowing>(0);
            }
        }

        public List<UserFollower> GetNewFollowers(string idUser)
        {
            //if (page == 0) page = 1;
            //if (limit == 0) limit = 20;
            //var skip = (page - 1) * limit;

            try
            {
                List<UserFollower> user = _db.UserFollowers
                    .Where(x => x.userId == long.Parse(idUser))
                    .OrderByDescending(x => x.follower.dateOfFollowing)
                    //.Skip(skip)
                    .Take(5)
                    .Include(x => x.follower.user)
                    .ToList();

                return user;
            }
            catch
            {
                return new List<UserFollower>(0);
            }
        }

        public List<UserFollowing> GetNewFollowings(string idUser)
        {
            //if (page == 0) page = 1;
            //if (limit == 0) limit = 20;
            //var skip = (page - 1) * limit;

            try
            {
                List<UserFollowing> user = _db.UserFollowings
                    .Where(x => x.userId == long.Parse(idUser))
                    .OrderByDescending(x => x.following.dateOfFollowing)
                    //.Skip(skip)
                    .Take(5)
                    .Include(x => x.following.user)
                    .ToList();

                return user;
            }
            catch
            {
                return new List<UserFollowing>(0);
            }
        }

        public User UpdateUser(User user)
        {
            try
            {
                Address address = _db.Addresses.FirstOrDefault(x => x.id == user.address.id);
                if (address != null)
                {
                    address.city = user.address.city;
                    address.country = user.address.country;
                    _db.SaveChanges();
                }

                User u = _db.Users
                    .Where(x => x.id == user.id)
                    .Include(x => x.address)
                    .FirstOrDefault();

                u.firstName = user.firstName;
                u.lastName = user.lastName;
                u.username = user.username;
                u.email = user.email;
                u.sex = user.sex;
                u.isPublicProfile = user.isPublicProfile;
                u.relationship = user.relationship;
                u.dateOfBirth = user.dateOfBirth;
                _db.SaveChanges();

                return u;
            }
            catch
            {
                return new User();
            }
        }

        public bool ChangePassword(long id, string oldPassword, string newPasswor)
        {
            try
            {
                User u = _db.Users
                    .Where(x => x.id == id)
                    .FirstOrDefault();

                var oldPasswordEnc = encoder.Encode(oldPassword);
                bool areEquals = encoder.Compare(oldPassword, u.password);

                if (u != null && areEquals)
                {
                    u.password = encoder.Encode(newPasswor);
                    _db.SaveChanges();

                    return true;

                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}