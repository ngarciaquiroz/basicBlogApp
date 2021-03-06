using basicBlogAppBusiness.Interfaces;
using basicBlogAppModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace basicBlogApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPostsLogic _postsLogic;
       

        public HomeController(IPostsLogic postsLogic)
        {

            _postsLogic = postsLogic;
        }

        public IActionResult Index()
        {
            var posts = _postsLogic.AllPostsByState(a => a.WorkflowStates == States.Publish);
            return View(posts);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Mocks Login process adding a cookie that will be used to
        /// check the user role
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string username)
        {
            username = username.ToLower();

            switch (username)
            {
                case Constants.WRITER_ROLE:
                    Response.Cookies.Append(Constants.COOKIE_NAME, UserRoles.Writer.ToString());
                    break;
                case Constants.EDITOR_ROLE:
                    Response.Cookies.Append(Constants.COOKIE_NAME, UserRoles.Editor.ToString());

                    break;
                default:
                    ViewBag.Error = "Wrong Credentials!!!";
                    return RedirectToAction("Login");

            }
            return RedirectToAction("Manage", "Post");

        }

        /// <summary>
        /// Removes the role cookie
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            Response.Cookies.Delete(Constants.COOKIE_NAME);
            return RedirectToAction("Index");
        }

    }
}
