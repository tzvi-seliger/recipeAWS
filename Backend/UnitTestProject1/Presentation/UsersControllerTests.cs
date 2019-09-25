using AspNetCoreWebApplication.Controllers;
using AspNetCoreWebApplication.DAO;
using AspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace MSTestRecipesAWS.Presentation
{
    [TestClass]
    public class UsersControllerTests
    {
        private UsersController _UnderTest;
        public UsersController UnderTest
        {
            get
            {
                if (_UnderTest == null) _UnderTest = new UsersController();
                return _UnderTest;

            }
        }

        [TestMethod]
        public void UserController_ModelIsNotNull()
        {
            Assert.IsNotNull(UnderTest, "MODEL WAS NULL");

        }

        [TestMethod]
        public void UserController_IsType_ViewResult()
        {
            //arrange
            var resultType = typeof(ViewResult);

            //act
            var executeController = UnderTest.Index();

            //Assert
            Assert.IsInstanceOfType(executeController, resultType);
        }

    }
}
