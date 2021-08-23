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
        public DbSet<Follower> Followers { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.email, u.username })
                .IsUnique();

            modelBuilder.Entity<UserPost>()
                .HasKey(up => new { up.postId, up.userId });

            modelBuilder.Entity<PostComment>()
                .HasKey(pm => new { pm.postId, pm.commentId });

            modelBuilder.Entity<PostReaction>()
                .HasKey(pr => new { pr.postId, pr.reactionId });

            modelBuilder.Entity<UserFollower>()
                .HasKey(uf => new { uf.userId, uf.followerId });

            modelBuilder.Entity<UserFollowing>()
                .HasKey(uf => new { uf.userId, uf.followerId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
