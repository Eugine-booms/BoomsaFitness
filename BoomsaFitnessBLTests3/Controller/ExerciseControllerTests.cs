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
    public class ExerciseControllerTests
    {
        

        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var usercontroller = new UserController(userName);
            var exerciseController = new ExerciseController(usercontroller.CurentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            //Act
            exerciseController.Add(activity, DateTime.UtcNow.AddMinutes(rnd.Next(10, 20)), DateTime.UtcNow);
            
            //Assert
            var exerciseController2 = new ExerciseController(new User(userName));
            
            //Assert.AreEqual(eatingController.Foods.Count, new EatingController(new UserController(userName).CurentUser).Eating.Foods.Count);
            Assert.AreEqual(activity.Name, exerciseController2.Activitys.Last().Name);
            Assert.AreEqual(activity.CaloriesPerMinute, exerciseController2.Activitys.Last().CaloriesPerMinute);
            Assert.AreEqual(activityName, exerciseController.Activitys.Last().Name);

        }
    }
}