using Moq;
using NUnit.Framework;
using SampleMVCTogetherApp.Models;
using SampleMVCTogetherApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVCTogetherTest
{
    //change to public access
    public class UserActionTest
    {
        [Test]
        public void SimpleTest()
        {
            //Arrange
            //IRepo<string, User> repo = new UserRepo();
            //LoginService service = new LoginService(repo);
            //User user = new User() { Username: "abc", Pasword}

            //Arrange
            Mock<UserRepo> mockRepo = new Mock<UserRepo>();
            mockRepo.Setup(x => x.Get("halimr")).Returns(new User { Username = "halimr", Password = "test123" });
            LoginService service = new LoginService(mockRepo.Object);
            User user = new User() { Username = "halimr", Password = "test123" };
            //Act
            var resultuser = service.LoginCheck(user);
            //Assert
            //Assert.Equals(user.Username, user.Password);
            Assert.IsNotNull(resultuser);

        }
    }
}
