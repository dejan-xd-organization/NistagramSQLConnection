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

        public bool RegistrationUser(string firstName, string lastName, string username, string email,
            string password, string sex, DateTime dateOfBirth, DateTime dateOfRegistration)
        {
            User user = new User(firstName, lastName, username, email, sex, dateOfBirth, dateOfRegistration);
            user.password = encoder.Encode(password);
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private List<User> FindAll()
        {
            return _db.Users.OrderBy(i => i.username).ToList();
        }


    }
}
