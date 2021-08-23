﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NistagramSQLConnection.Data;

namespace NistagramSQLConnection.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("NistagramSQLConnection.Model.Address", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("city")
                        .HasColumnType("longtext");

                    b.Property<string>("country")
                        .HasColumnType("longtext");

                    b.Property<int>("postCode")
                        .HasColumnType("int");

                    b.Property<string>("region")
                        .HasColumnType("longtext");

                    b.Property<string>("street")
                        .HasColumnType("longtext");

                    b.Property<string>("streetNumber")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Comment", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("comment")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("timeDateComments")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Follower", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool?>("accepted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("dateOfFollowing")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("follower");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.PostComment", b =>
                {
                    b.Property<long>("postId")
                        .HasColumnType("bigint");

                    b.Property<long>("commentId")
                        .HasColumnType("bigint");

                    b.HasKey("postId", "commentId");

                    b.HasIndex("commentId");

                    b.ToTable("PostComment");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.PostReaction", b =>
                {
                    b.Property<long>("postId")
                        .HasColumnType("bigint");

                    b.Property<long>("reactionId")
                        .HasColumnType("bigint");

                    b.HasKey("postId", "reactionId");

                    b.HasIndex("reactionId");

                    b.ToTable("PostReaction");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Reaction", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool?>("type")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("reaction");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Role", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("addressId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("dateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dateOfRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("isPublicProfile")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("profileImg")
                        .HasColumnType("longtext");

                    b.Property<string>("relationship")
                        .HasColumnType("longtext");

                    b.Property<long?>("roleId")
                        .HasColumnType("bigint");

                    b.Property<string>("sex")
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("id");

                    b.HasIndex("addressId");

                    b.HasIndex("roleId");

                    b.HasIndex("email", "username")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.UserFollower", b =>
                {
                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.Property<long>("followerId")
                        .HasColumnType("bigint");

                    b.HasKey("userId", "followerId");

                    b.HasIndex("followerId");

                    b.ToTable("UserFollowers");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.UserFollowing", b =>
                {
                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.Property<long>("followerId")
                        .HasColumnType("bigint");

                    b.HasKey("userId", "followerId");

                    b.HasIndex("followerId");

                    b.ToTable("UserFollowing");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.UserPost", b =>
                {
                    b.Property<long>("postId")
                        .HasColumnType("bigint");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("postId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("UserPost");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.WallPost", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("imagePost")
                        .HasColumnType("longtext");

                    b.Property<bool>("isPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("postDescription")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("timePublis")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("wallpost");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Comment", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Follower", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.PostComment", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.Comment", "comment")
                        .WithMany("postComments")
                        .HasForeignKey("commentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NistagramSQLConnection.Model.WallPost", "wallPost")
                        .WithMany("postComments")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comment");

                    b.Navigation("wallPost");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.PostReaction", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.WallPost", "wallPost")
                        .WithMany("postReactions")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NistagramSQLConnection.Model.Reaction", "reaction")
                        .WithMany("postReactions")
                        .HasForeignKey("reactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reaction");

                    b.Navigation("wallPost");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Reaction", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.User", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressId");

                    b.HasOne("NistagramSQLConnection.Model.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleId");

                    b.Navigation("address");

                    b.Navigation("role");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.UserFollower", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.Follower", "follower")
                        .WithMany()
                        .HasForeignKey("followerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NistagramSQLConnection.Model.User", "user")
                        .WithMany("userFollowers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("follower");

                    b.Navigation("user");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.UserFollowing", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.Follower", "follower")
                        .WithMany()
                        .HasForeignKey("followerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NistagramSQLConnection.Model.User", "user")
                        .WithMany("userFollowings")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("follower");

                    b.Navigation("user");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.UserPost", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.WallPost", "wallPost")
                        .WithMany("userPosts")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NistagramSQLConnection.Model.User", "user")
                        .WithMany("userPosts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");

                    b.Navigation("wallPost");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Comment", b =>
                {
                    b.Navigation("postComments");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Reaction", b =>
                {
                    b.Navigation("postReactions");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.User", b =>
                {
                    b.Navigation("userFollowers");

                    b.Navigation("userFollowings");

                    b.Navigation("userPosts");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.WallPost", b =>
                {
                    b.Navigation("postComments");

                    b.Navigation("postReactions");

                    b.Navigation("userPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
