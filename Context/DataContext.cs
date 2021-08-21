using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NistagramSQLConnection.Model;

namespace NistagramSQLConnection.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<WallPost> WallPosts { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => new { u.email, u.username })
                .IsUnique();

            builder.Entity<UserPost>()
                .HasKey(up => new { up.postId, up.userId });

            builder.Entity<PostComment>()
                .HasKey(pm => new { pm.postId, pm.commentId });

            builder.Entity<PostReaction>()
                .HasKey(pr => new { pr.postId, pr.reactionId });

            base.OnModelCreating(builder);
        }

    }
}
