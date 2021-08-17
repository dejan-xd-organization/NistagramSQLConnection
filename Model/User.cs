using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NistagramSQLConnection.Model;

namespace NistagramSQLConnection.Model
{
    [Table("user")]
    public class User
    {
        [Key]
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string profileImg { get; set; }
        public string sex { get; set; }
        public Address address { get; set; }
        public string relationship { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime dateOfRegistration { get; set; }
        public Role role { get; set; }

        public User() { }
        public User(long id, string firstName, string lastName, string username, string email, string password, string profileImg,
             string sex, Address address, string relationship, DateTime dateOfBirth, DateTime dateOfRegistration, Role role)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.email = email;
            this.password = password;
            this.profileImg = profileImg;
            this.sex = sex;
            this.address = address;
            this.relationship = relationship;
            this.dateOfBirth = dateOfBirth;
            this.dateOfRegistration = dateOfRegistration;
            this.role = role;

        }

        public User(string firstName, string lastName, string username, string email, string sex, DateTime dateOfBirth, DateTime dateOfRegistration)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.email = email;
            this.sex = sex;
            this.dateOfBirth = dateOfBirth;
            this.dateOfRegistration = dateOfRegistration;

        }

    }
}
