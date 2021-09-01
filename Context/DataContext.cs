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
        public DbSet<Following> Followings { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<UserFollowing> UserFollowings { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<ChatBoxMessages> ChatBoxMessages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatBox> ChatBoxes { get; set; }

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

            modelBuilder.Entity<ChatBoxMessages>()
                .HasKey(cm => new { cm.chatBoxId, cm.messageId });



            modelBuilder.Entity<UserPost>()
                .HasOne(bc => bc.wallPost)
                .WithMany(b => b.userPosts)
                .HasForeignKey(bc => bc.postId);
            modelBuilder.Entity<UserPost>()
                .HasOne(bc => bc.user)
                .WithMany(c => c.userPosts)
                .HasForeignKey(bc => bc.userId);

            modelBuilder.Entity<PostComment>()
                .HasOne(bc => bc.comment)
                .WithMany(b => b.postComments)
                .HasForeignKey(bc => bc.commentId);
            modelBuilder.Entity<PostComment>()
                .HasOne(bc => bc.wallPost)
                .WithMany(c => c.postComments)
                .HasForeignKey(bc => bc.postId);

            modelBuilder.Entity<PostReaction>()
                .HasOne(bc => bc.reaction)
                .WithMany(b => b.postReactions)
                .HasForeignKey(bc => bc.reactionId);
            modelBuilder.Entity<PostReaction>()
                .HasOne(bc => bc.wallPost)
                .WithMany(c => c.postReactions)
                .HasForeignKey(bc => bc.postId);

            modelBuilder.Entity<UserFollower>()
                .HasOne(bc => bc.follower)
                .WithMany(b => b.userFollowers)
                .HasForeignKey(bc => bc.followerId);
            modelBuilder.Entity<UserFollower>()
                .HasOne(bc => bc.user)
                .WithMany(c => c.userFollowers)
                .HasForeignKey(bc => bc.userId);

            modelBuilder.Entity<UserFollowing>()
                .HasOne(bc => bc.following)
                .WithMany(b => b.userFollowings)
                .HasForeignKey(bc => bc.followerId);
            modelBuilder.Entity<UserFollowing>()
                .HasOne(bc => bc.user)
                .WithMany(c => c.userFollowings)
                .HasForeignKey(bc => bc.userId);

            modelBuilder.Entity<ChatBoxMessages>()
                .HasOne(bc => bc.chatBox)
                .WithMany(c => c.chatBoxMessages)
                .HasForeignKey(bc => bc.chatBoxId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
