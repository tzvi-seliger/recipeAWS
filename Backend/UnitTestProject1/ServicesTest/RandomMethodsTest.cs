using AspNetCoreWebApplication.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSTestRecipesAWS.ServicesTest
{
    [TestClass]
    public class RandomMethodsTest
    {
        [TestMethod]
        public void ToTitleLower()
        {
            //arrange
            string lowerResult = RandomMethods.ToTitle("hello how are you");

            //act
            //assert
            Assert.AreEqual("Hello How Are You", lowerResult, "not correct");
        }

        [TestMethod]
        public void ToTitleUpper()
        {
            string upperresult = RandomMethods.ToTitle("HELLO HOW ARE YOU");
            Assert.AreEqual("Hello How Are You", upperresult, "upper case doesn't convert properly");
        }

        [TestMethod]
        public void getSq()
        {
            double geteightByEight = RandomMethods.getSq(8, 8);
            Assert.AreEqual(64, geteightByEight, $"should equal 64 but equals {geteightByEight}");
        }

        [TestMethod]
        public void getRatio88to913()
        {
            double convert1UnitFromEightByEightToNineByThirteen = RandomMethods.getRatio(1, RandomMethods.getSq(8, 8), RandomMethods.getSq(9, 13));
            Assert.AreEqual(1.8281, convert1UnitFromEightByEightToNineByThirteen, "not working");
        }

        [TestMethod]
        public void getRatio913to88()
        {
            double convert1UnitFromNineByThirteenToightByEight = RandomMethods.getRatio(1, RandomMethods.getSq(9, 13), RandomMethods.getSq(8, 8));
            Assert.AreEqual(0.5470, convert1UnitFromNineByThirteenToightByEight, "not working");
        }
    }
}