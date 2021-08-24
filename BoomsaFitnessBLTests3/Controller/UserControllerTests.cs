using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoomsaFitnessBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoomsaFitnessBL.Model;

namespace BoomsaFitnessBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurentUser.Name);
        }

        [TestMethod()]
        public void CreateNewUserTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var userController = new UserController(userName);
            //Act

            userController.CreateNewUser(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller2.CurentUser.Name);
            Assert.AreEqual(weight, controller2.CurentUser.Weight);
            Assert.AreEqual(height, controller2.CurentUser.Height);
            Assert.AreEqual(gender, controller2.CurentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller2.CurentUser.BirthDate);



        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var userController = new UserController(userName);
            //Act

            userController.CreateNewUser(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            controller2.DeleteCurentUser();
            var controller3 = new UserController("Вася");
            //Assert
            Assert.AreEqual(null, controller3.Users.SingleOrDefault(s=>s.Name==userName));
          
        }
    }
}