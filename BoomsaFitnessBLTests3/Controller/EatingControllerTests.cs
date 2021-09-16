using BoomsaFitnessBL.Controller;
using BoomsaFitnessBL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BoomsaFitnessBL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var usercontroller = new UserController(userName);
            var eatingController = new EatingController(usercontroller.CurentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            //Act
            eatingController.Add(food, 100);
            var eatControl = new EatingController(usercontroller.CurentUser)
                .Eating
                .Foods
                .Count;
            //Assert
            Assert.AreEqual(eatingController
                .Foods
                .Count,
                new EatingController(new UserController(userName).CurentUser)
                .Eating
                .Foods
                .Count);
            Assert.AreEqual(food.Name, eatingController
                                         .Eating
                                         .Foods
                                         .Last()
                                         .Key
                                         .Name);
        }
    }
}
