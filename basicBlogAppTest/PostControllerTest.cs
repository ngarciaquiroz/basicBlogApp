using basicBlogApp.Models;
using basicBlogAppBusiness.Interfaces;
using basicBlogAppModels;
using BlogApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace basicBlogAppTest
{
    public class PostControllerTest
    {
        [Fact]
        public void IndexCallTheBusinessLogicOnce()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var postController = new PostController(mockPostLogic.Object);
            mockPostLogic.Setup(mock => mock.AllPosts());
            //Act
            postController.Index();

            //Assert
            mockPostLogic.Verify(mock => mock.AllPosts(), Times.Once());
        }

        [Fact]
        public void ManageCallUnauthenticatedUser()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var postController = new PostController(mockPostLogic.Object);
            postController.ControllerContext.HttpContext = new DefaultHttpContext();
            mockPostLogic.Setup(mock => mock.AllPostsByState(a => a.WorkflowStates == States.Publish));
            //Act
            RedirectToActionResult result = (RedirectToActionResult)postController.Manage();

            //Assert

            Assert.True(result.ActionName.Equals("Index"));
            Assert.True(result.ControllerName.Equals("Home"));
        }


        [Fact]
        public void ManageCallAuthenticatedUserWriter()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var postController = new PostController(mockPostLogic.Object);
            var fakeHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            var mockCookies = new Mock<IRequestCookieCollection>();
            mockCookies.Setup(a => a[Constants.COOKIE_NAME]).Returns(Constants.WRITER_ROLE);
            fakeHttpContext.Setup(a => a.Request).Returns(mockRequest.Object);
            mockRequest.Setup(a => a.Cookies).Returns(mockCookies.Object);

            postController.ControllerContext.HttpContext = fakeHttpContext.Object;
            mockPostLogic.Setup(mock => mock.AllPostsByState(a => a.WorkflowStates == States.Draft || a.WorkflowStates == States.PendingApproval));

            //Act
            postController.Manage();

            //Assert

            mockPostLogic.VerifyAll();
            mockCookies.VerifyAll();
            mockRequest.VerifyAll();
        }


        [Fact]
        public void ManageCallAuthenticatedUserEditor()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var postController = new PostController(mockPostLogic.Object);
            var fakeHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            var mockCookies = new Mock<IRequestCookieCollection>();
            mockCookies.Setup(a => a[Constants.COOKIE_NAME]).Returns(Constants.EDITOR_ROLE);
            fakeHttpContext.Setup(a => a.Request).Returns(mockRequest.Object);
            mockRequest.Setup(a => a.Cookies).Returns(mockCookies.Object);

            postController.ControllerContext.HttpContext = fakeHttpContext.Object;
            mockPostLogic.Setup(mock => mock.AllPostsByState(a => a.WorkflowStates == States.PendingApproval || a.WorkflowStates == States.Publish));

            //Act
            postController.Manage();

            //Assert

            mockPostLogic.VerifyAll();
            mockCookies.VerifyAll();
            mockRequest.VerifyAll();
        }

        [Fact]
        public void AddCallPostViewModelDraft()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var postController = new PostController(mockPostLogic.Object);
            var fakeHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            var formMock = new Mock<IFormCollection>();

            fakeHttpContext.Setup(a => a.Request).Returns(mockRequest.Object);
            mockRequest.Setup(req => req.Form).Returns(formMock.Object);
            formMock.Setup(a => a.Keys).Returns(new List<string> { "Save" });
            postController.ControllerContext.HttpContext = fakeHttpContext.Object;


            var model = new PostViewModel
            {
                Title = "Test",
                Content = "Test Content",
                Author = "test Author"
            };

            mockPostLogic.Setup(mock => mock.AddOrEdit(new Post
            {
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                WorkflowStates = States.PendingApproval

            }));


            //Act
            postController.Add(model);

            //Assert

            mockPostLogic.Verify(mock => mock.AddOrEdit(It.IsAny<Post>()));
            mockRequest.VerifyAll();
        }
        [Fact]
        public void AddCallPostViewModelsubmitApproval()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var postController = new PostController(mockPostLogic.Object);
            var fakeHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            var formMock = new Mock<IFormCollection>();

            fakeHttpContext.Setup(a => a.Request).Returns(mockRequest.Object);
            mockRequest.Setup(req => req.Form).Returns(formMock.Object);
            formMock.Setup(a => a.Keys).Returns(new List<string> { "submitApproval" });
            postController.ControllerContext.HttpContext = fakeHttpContext.Object;


            var model = new PostViewModel
            {
                Title = "Test",
                Content = "Test Content",
                Author = "test Author"
            };

            mockPostLogic.Setup(mock => mock.AddOrEdit(new Post
            {
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                WorkflowStates = States.PendingApproval

            }));


            //Act
            postController.Add(model);

            //Assert

            mockPostLogic.Verify(mock => mock.AddOrEdit(It.IsAny<Post>()));
            mockRequest.VerifyAll();
        }

        [Fact]
        public void AddCallPostViewModelsubmitPublish()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var postController = new PostController(mockPostLogic.Object);
            var fakeHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            var formMock = new Mock<IFormCollection>();

            fakeHttpContext.Setup(a => a.Request).Returns(mockRequest.Object);
            mockRequest.Setup(req => req.Form).Returns(formMock.Object);
            formMock.Setup(a => a["Approver"]).Returns("Approver");
            formMock.Setup(a => a.Keys).Returns(new List<string> { "Approved" });

            postController.ControllerContext.HttpContext = fakeHttpContext.Object;


            var model = new PostViewModel
            {
                Title = "Test",
                Content = "Test Content",
                Author = "test Author",
            };

            mockPostLogic.Setup(mock => mock.AddOrEdit(new Post
            {
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                WorkflowStates = States.Publish
            }));


            //Act
            postController.Add(model);

            //Assert

            mockPostLogic.Verify(mock => mock.AddOrEdit(It.IsAny<Post>()));
            mockRequest.VerifyAll();
        }

        [Fact]
        public void AddCallPostViewModelsubmitPublishWithOutApprover()
        {
            //Arrange
            var mockPostLogic = new Mock<IPostsLogic>();
            var postController = new PostController(mockPostLogic.Object);
            var fakeHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            var formMock = new Mock<IFormCollection>();

            fakeHttpContext.Setup(a => a.Request).Returns(mockRequest.Object);
            mockRequest.Setup(req => req.Form).Returns(formMock.Object);
            formMock.Setup(a => a.Keys).Returns(new List<string>());
            postController.ControllerContext.HttpContext = fakeHttpContext.Object;


            var model = new PostViewModel
            {
                Title = "Test",
                Content = "Test Content",
                Author = "test Author"
            };

            mockPostLogic.Setup(mock => mock.AddOrEdit(new Post
            {
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                WorkflowStates = States.Publish
            }));


            //Act
            postController.Add(model);

            //Assert
            mockPostLogic.Verify(mock => mock.AddOrEdit(It.IsAny<Post>()), Times.Never());
            mockRequest.VerifyAll();
        }

    }
}
