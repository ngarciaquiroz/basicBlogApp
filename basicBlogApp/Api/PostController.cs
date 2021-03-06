
using basicBlogAppBusiness.Interfaces;
using basicBlogAppModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BlogApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostsLogic _postsLogic;
        private readonly List<string> actions = new List<string> { "approve", "reject" };

        public PostController(IPostsLogic postsLogic)
        {
            _postsLogic = postsLogic;
        }
        /// <summary>
        /// Returns all the post with the status pending for approval
        /// </summary>
        /// <returns></returns>
        [HttpGet("PendingPosts")]
        public IActionResult PendingPosts()
        {
            return Ok( _postsLogic.AllPostsByState(a => a.WorkflowStates == States.PendingApproval));
        }

        /// <summary>
        /// Allows the editor to approve or reject a post
        /// </summary>
        /// <param name="postId">Post unique Id</param>
        /// <param name="action"> Editor option "approve" or "reject" </param>
        /// <returns></returns>

        [HttpPost("ChangePostState")]
        public IActionResult ChangePostState(int postId, string action, string approver)
        {
            var post = _postsLogic.GetPost(postId);
            if(post.WorkflowStates == States.PendingApproval && actions.Contains(action))
            {
                post.WorkflowStates = action.Equals("approve") ? States.Publish : States.Draft;
                post.Approver = approver;
                _postsLogic.AddOrEdit(post);
                return Ok(post);
            }
            return BadRequest();
        }
    }
}
