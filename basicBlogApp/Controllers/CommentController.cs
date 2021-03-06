using basicBlogAppBusiness.Interfaces;
using basicBlogAppModels;
using BlogAppBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace basicBlogApp.Controllers
{
    public class CommentController : Controller
    {
        private ICommentsLogic _commentsLogic;
        private IPostsLogic _postLogic;

        public CommentController(ICommentsLogic commentsLogic, IPostsLogic postLogic)
        {
            _commentsLogic = commentsLogic;
            _postLogic = postLogic;
        }
        /// <summary>
        /// Adds a comments and takes the user back to the page 
        /// of the post
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentsLogic.AddComment(comment);
                return RedirectToAction("Single", "Post", new { Id = comment.PostId });
            }
            return View(comment);
        }
     
        public ActionResult Add(int id)
        {
            var post = _postLogic.GetPost(id);
            ViewBag.Post = post;
            var comment = new Comment { PostId = id };
            return View(comment);
        }
    }
}
