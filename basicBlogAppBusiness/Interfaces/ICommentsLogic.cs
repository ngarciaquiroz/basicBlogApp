using basicBlogAppModels;
using System.Collections.Generic;


namespace BlogAppBusiness.Interfaces
{
    public interface ICommentsLogic
    {
        IEnumerable<Comment> AllComments();
        Comment Comment(int id);
        void AddComment(Comment comment);
    }
}
