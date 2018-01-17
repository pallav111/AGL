using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGL.Controllers;
using System.Web.Mvc;
using System.Net;
using System.Collections.Generic;
using AGL.Models;
using System.Linq;

namespace AGLTestProject
{
    [TestClass]
    public class AGLHomeControllerTest
    {
        [TestMethod]
        public void TestDisplayModel()
        {
            //Test Data
            List<string> expectedfemaleList = new List<string> { "Garfield", "Simba", "Tabby" };
            List<string> expectedmaleList = new List<string> { "Garfield", "Jim", "Max", "Tom" };

            // Arrange
            var controller = new HomeController();
            
            // Act
            var result = controller.Index() as ViewResult;
            HomeModel hm = result.Model as HomeModel;
            List<string> actualfemaleList = hm.CatsOfFemales;
            List<string> actualmaleList = hm.CatsOfMales;


            // Assert
            Assert.IsTrue(actualfemaleList.All(expectedfemaleList.Contains) && actualfemaleList.Count == expectedfemaleList.Count);
            Assert.IsTrue(actualmaleList.All(expectedmaleList.Contains) && actualmaleList.Count == expectedmaleList.Count);
        }
    }
}
