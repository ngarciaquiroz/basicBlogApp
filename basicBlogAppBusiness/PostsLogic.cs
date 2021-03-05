
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using basicBlogAppModels;
using basicBlogAppRepository;
using basicBlogAppBusiness.Interfaces;

namespace BlogAppBusiness
{
    public class PostsLogic :IPostsLogic
    {
        private IRepository<Post> _postRepository;

        public PostsLogic(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Post> AllPosts()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Post> AllPostsByState(Expression<Func<Post, bool>> filter = null)
        {
            return _postRepository.Get(filter);
        }

        public Post GetPost(int id)
        {
            return _postRepository.Get(filter: a => a.ID == id, includeProperties: "Comments").FirstOrDefault();
        }

        public void AddOrEdit(Post post)
        {
            if (post.ID == 0)
            {
                post.PublishDate = DateTime.Now;
                _postRepository.Add(post);
            }
            else
            {
                Update(post);
            }
        }

        private void Update(Post post)
        {
            var currentPost = _postRepository.Get(post.ID);
            if (currentPost != null)
            {
                currentPost.ModifiedDate = DateTime.Now;
                currentPost.Title = post.Title;
                currentPost.Author = post.Author;
                currentPost.Content = post.Content;
                currentPost.WorkflowStates = post.WorkflowStates;
                currentPost.Approver = post.Approver;
                currentPost.ApprovalDate = post.ApprovalDate;
                _postRepository.Save();
            }
        }

        public void Delete(int id)
        {
            var currentPost = _postRepository.Get(id);
            if (currentPost != null)
            {
                _postRepository.Remove(currentPost);
            }
        }
    }
}
