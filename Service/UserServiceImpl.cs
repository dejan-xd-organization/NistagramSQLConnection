using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NistagramSQLConnection.Data;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using Scrypt;

namespace NistagramSQLConnection.Service
{
    public class UserServiceImpl : IUserService
    {
        private readonly DataContext _db;
        ScryptEncoder encoder = new ScryptEncoder();

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
            catch (Exception e)
            {
                return null;
            }
        }

        public bool RegistrationUser(User u)
        {
            User user = new User(u.firstName, u.lastName, u.username, u.email, u.sex, u.dateOfBirth, u.dateOfRegistration);
            user.password = encoder.Encode(u.password);
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
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
                return _db.Users.OrderBy(x => x.dateOfRegistration).Skip(Math.Max(0, _db.Users.Count() - 2)).ToList();
            }
            catch
            {
                return new List<User>(0);
            }
        }

        public User FindUserById(long id, bool isOnline = false)
        {
            try
            {
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

    }
}