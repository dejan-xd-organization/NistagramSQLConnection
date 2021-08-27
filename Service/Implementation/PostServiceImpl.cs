using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NistagramSQLConnection.Data;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;

namespace NistagramSQLConnection.Service
{
    public class PostServiceImpl : IPostService
    {

        private readonly DataContext _db;

        public PostServiceImpl(DataContext db)
        {
            _db = db;
        }

        public List<WallPost> GetAllWallPosts(List<bool> isPublic, int page, int limit)
        {
            if (page == 0) page = 1;
            if (limit == 0) limit = 20;
            var skip = (page - 1) * limit;

            try
            {
                return _db.WallPosts
                    .Where(x => isPublic.Contains(x.isPublic))
                    .OrderByDescending(x => x.timePublis)
                    .Skip(skip)
                    .Take(limit)
                    .Include(x => x.userPosts).ThenInclude(x => (x as UserPost).user)
                    .Include(x => x.postReactions).ThenInclude(x => (x as PostReaction).reaction)
                    .Include(x => x.postComments).ThenInclude(x => (x as PostComment).comment)

                    .ToList();
            }
            catch
            {
                return new List<WallPost>(0);
            }
        }

        public WallPost NewPost(long userId, string description, string imgLink, bool isPublic)
        {
            User user = _db.Users
                .Where(x => x.id == userId)
                .Include(x => x.userPosts)
                .FirstOrDefault();

            WallPost wallPost = new WallPost();
            wallPost.timePublis = DateTime.Now;
            wallPost.imagePost = imgLink;
            wallPost.postDescription = description;
            wallPost.isPublic = isPublic;

            _db.WallPosts.Add(wallPost);
            _db.SaveChanges();

            UserPost userPost = new UserPost();
            userPost.user = user;
            userPost.userId = user.id;
            userPost.wallPost = wallPost;
            userPost.postId = wallPost.id;

            _db.UserPosts.Add(userPost);
            _db.SaveChanges();

            user.userPosts.Add(userPost);
            _db.SaveChanges();

            return wallPost;

        }

        public bool PutReaction(long id, bool type, long userId)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(x => x.id == userId);

                if (user == null)
                {
                    return false;
                }

                Reaction reaction = new Reaction();
                reaction.type = type;
                reaction.user = user;


                _db.Reactions.Add(reaction);
                _db.SaveChanges();

                WallPost wallPost = _db.WallPosts
                    .Where(x => x.id == id)
                    .Include(x => x.postReactions)
                    .FirstOrDefault();

                PostReaction postReaction = new PostReaction();
                postReaction.wallPost = wallPost;
                postReaction.postId = wallPost.id;
                postReaction.reaction = reaction;
                postReaction.reactionId = reaction.id;
                _db.SaveChanges();

                wallPost.postReactions.Add(postReaction);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Reaction> GetAllReactions(List<long> id)
        {
            try
            {
                return _db.Reactions.Where(x => id.Contains(x.id)).ToList();
            }
            catch
            {
                return new List<Reaction>(0);
            }
        }

    }
}