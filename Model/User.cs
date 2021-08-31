using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NistagramSQLConnection.Model
{
    [Table("user")]
    public class User
    {
        [Key]
        public long id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        public string profileImg { get; set; }

        public string sex { get; set; }

        [ForeignKey("addressId")]
        public Address address { get; set; }

        public string relationship { get; set; }

        public DateTime? dateOfBirth { get; set; }

        public DateTime dateOfRegistration { get; set; }

        public bool isPublicProfile { get; set; }  // is user profile public or not?

        [ForeignKey("roleId")]
        public Role role { get; set; }

        public ICollection<UserPost> userPosts { get; set; }

        public ICollection<UserFollower> userFollowers { get; set; }

        public ICollection<UserFollowing> userFollowings { get; set; }

    }
}
