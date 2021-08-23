using Microsoft.EntityFrameworkCore;
using NistagramSQLConnection.Data;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;

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
                User user = _db.Users.SingleOrDefault(x => x.username == username);
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
                if (isOnline != true) isOnline = false;
                return (User)_db.Users.Where(x => x.isPublicProfile == isOnline).Where(x => x.id == id);
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

        public List<User> GetNewFollowers(string id)
        {
            List<UserFollower> userFollowers = _db.UserFollowers
                .Where(x => x.userId == long.Parse(id))
                .Include(uf => uf.follower)
                .ToList();

            List<User> user = new List<User>();
            foreach(UserFollower uf in userFollowers)
            {
                user.Add(uf.follower.user);
            }
            return user;
        }
    }
}