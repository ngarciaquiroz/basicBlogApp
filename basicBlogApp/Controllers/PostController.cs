using basicBlogApp.Models;
using basicBlogAppBusiness.Interfaces;
using basicBlogAppModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace BlogApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostsLogic _postsLogic;

        public PostController(IPostsLogic postsLogic)
        {
            _postsLogic = postsLogic;
        }
        public IActionResult Index()
        {
            var posts = _postsLogic.AllPosts();
            return View(posts);
        }

        public IActionResult Single(int id)
        {
            var Post = _postsLogic.GetPost(id);
            return View(Post);
        }

        public IActionResult Manage()
        {
            if (Request != null && Request.Cookies[Constants.COOKIE_NAME] != null)
            {
                var role = GetRoleFromCookie();
                IEnumerable<Post> posts = new List<Post>();
                switch (role)
                {
                    case UserRoles.Writer:
                        posts = _postsLogic.AllPostsByState(a => a.WorkflowStates == States.Draft || a.WorkflowStates == States.PendingApproval);
                        break;
                    case UserRoles.Editor:
                        posts = _postsLogic.AllPostsByState(a => a.WorkflowStates == States.PendingApproval || a.WorkflowStates == States.Publish);
                        break;
                }
                return View(posts);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Add(PostViewModel postView)
        {
            var post = GetPost(postView);
            post.WorkflowStates = Request.Form.Keys.Contains("Save") ? States.Draft : Request.Form.Keys.Contains("submitApproval") ? States.PendingApproval : States.Publish;
            if (post.WorkflowStates == States.Publish && String.IsNullOrEmpty(Request.Form["Approver"]))
            {
                ModelState.AddModelError("Approver", "The approver is required");
                return View("~/Views/Post/Add.cshtml", postView);
            }

            if (ModelState.IsValid)
            {
                if (post.WorkflowStates == States.Publish)
                {
                    post.ApprovalDate = DateTime.Now;
                }

                _postsLogic.AddOrEdit(post);
                return RedirectToAction("Manage");
            }
            return View(postView);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var post = _postsLogic.GetPost(id);

            return View("~/Views/Post/Add.cshtml", GetPostViewModel(post));
        }

        public IActionResult Delete(int id)
        {
            _postsLogic.Delete(id);
            return RedirectToAction("Manage", "Post");
        }

        private Post GetPost(PostViewModel post)
        {
            return new Post
            {
                ID = post.ID,
                Author = post.Author,
                Approver = post.Approver,
                Content = post.Content,
                Title = post.Title
            };
        }


        private PostViewModel GetPostViewModel(Post post)
        {
            return new PostViewModel
            {
                ID = post.ID,
                Author = post.Author,
                Approver = post.Approver,
                Content = post.Content,
                Title = post.Title
            };
        }
        /// <summary>
        /// This cookie as mock for the session
        /// </summary>
        /// <returns></returns>
        private UserRoles GetRoleFromCookie()
        {

            if (Request != null && Request.Cookies[Constants.COOKIE_NAME] != null)
            {
                return Enum.TryParse(Request.Cookies[Constants.COOKIE_NAME], true, out UserRoles role) ? role
               : UserRoles.Anon;

            }
            return UserRoles.Writer;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewBag.Role = GetRoleFromCookie();
        }
        
    }
}
