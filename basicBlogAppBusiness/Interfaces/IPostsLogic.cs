
using basicBlogAppModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace basicBlogAppBusiness.Interfaces
{
    public interface IPostsLogic
    {
        IEnumerable<Post> AllPosts();
        Post GetPost(int id);
        void AddOrEdit(Post post);
        void Delete(int id);
        IEnumerable<Post> AllPostsByState(Expression<Func<Post, bool>> filter = null);
    }
}
