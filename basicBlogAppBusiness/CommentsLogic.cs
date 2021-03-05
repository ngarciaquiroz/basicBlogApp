

using basicBlogAppModels;
using basicBlogAppRepository;
using BlogAppBusiness.Interfaces;
using System.Collections.Generic;


namespace BlogAppBusiness
{
    public class CommentsLogic : ICommentsLogic
    {
        private IRepository<Comment> _commentRepository;

        public CommentsLogic(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<Comment> AllComments()
        {
            return _commentRepository.GetAll();
        }

        public Comment Comment(int id)
        {
            return _commentRepository.Get(id);
        }

        public void AddComment(Comment comment)
        {
            _commentRepository.Add(comment);
        }      
    }
}
