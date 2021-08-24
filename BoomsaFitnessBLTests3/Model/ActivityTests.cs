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
    public class ActivityTests
    {
        

        [TestMethod()]
        public void ToStringTest()
        {
            //Arrange
            var name = Guid.NewGuid().ToString();
            var rnd = new Random();
            //Act
            var activity = new Activity(name, rnd.Next(100,500));


            //Assert
            Assert.AreEqual(name, activity.ToString());
        }
    }
}