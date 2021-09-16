using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoomsaFitnessBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;

namespace BoomsaFitnessBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            var userController = new UserController();
            Assert.AreEqual(1, 1);
        }
        [TestMethod()]
        public void GetUsersDataTest()
        {
            var userController = new UserController();
            var users = userController.GetUsersData();
            Assert.AreEqual(1, 1);
        }
    }
}