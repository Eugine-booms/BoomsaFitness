using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoomsaFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomsaFitnessBL.Model.Tests
{
    [TestClass()]
    public class ExerciseTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            //Arrange
            var userName= Guid.NewGuid().ToString();
            var name = Guid.NewGuid().ToString();
            var start = DateTime.Now;
            var finish = start.AddMinutes(-50);
            var rnd = new Random();
            //Act
            var exercise = new Exercise(start, finish , new User(userName), new Activity(name, rnd.Next()));
            //Assert
            Assert.AreEqual($"{name} дата {start.ToShortDateString()} начало {start.ToShortTimeString()} - конец {finish.ToShortTimeString()}",exercise.ToString());
        }
        
    }
}