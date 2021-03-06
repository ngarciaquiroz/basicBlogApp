using basicBlogApp.Controllers;
using basicBlogAppBusiness.Interfaces;
using basicBlogAppModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace basicBlogAppTest
{
   public class HomeControllerTest
    {
     

        [Fact]
        public void IndexCallTheBusinessLogicOnce()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var homeController = new HomeController(mockPostLogic.Object);
            mockPostLogic.Setup(mock => mock.AllPostsByState(a => a.WorkflowStates == States.Publish));
            //Act
            homeController.Index();

            //Assert
            mockPostLogic.Verify(mock => mock.AllPostsByState(a => a.WorkflowStates == States.Publish), Times.Once());
        }

        [Fact]
        public void LoginUsingEditorRole()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var homeController = new HomeController(mockPostLogic.Object);
          
            homeController.ControllerContext.HttpContext = new DefaultHttpContext();
            //Act
            RedirectToActionResult result = (RedirectToActionResult)homeController.Login(Constants.EDITOR_ROLE);

            //Assert
            Assert.True(result.ActionName.Equals("Manage"));
            Assert.True(result.ControllerName.Equals("Post"));
            Assert.True(homeController.ControllerContext.HttpContext.Response.Headers.ContainsKey("Set-Cookie"));
        }


        [Fact]
        public void LoginUsingWriterRole()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var homeController = new HomeController(mockPostLogic.Object);
           
            homeController.ControllerContext.HttpContext = new DefaultHttpContext();
            //Act
            RedirectToActionResult result = (RedirectToActionResult)homeController.Login(Constants.EDITOR_ROLE);

            //Assert
            Assert.True(result.ActionName.Equals("Manage"));
            Assert.True(result.ControllerName.Equals("Post"));
            Assert.True(homeController.ControllerContext.HttpContext.Response.Headers.ContainsKey("Set-Cookie"));
        }

        [Fact]
        public void LoginUsingUnknownRole()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var homeController = new HomeController(mockPostLogic.Object);
            var user = "powerUSer";
            homeController.ControllerContext.HttpContext = new DefaultHttpContext();
            //Act
            RedirectToActionResult result = (RedirectToActionResult)homeController.Login(user);

            //Assert
            Assert.True(result.ActionName.Equals("Login"));

        }

        [Fact]
        public void LogOut()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var homeController = new HomeController(mockPostLogic.Object);
            homeController.ControllerContext.HttpContext = new DefaultHttpContext();
            //Act
            RedirectToActionResult result = (RedirectToActionResult)homeController.Logout();

            //Assert
            Assert.True(result.ActionName.Equals("Login"));

        }
    }
}
