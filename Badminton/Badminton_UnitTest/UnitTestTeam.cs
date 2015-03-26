using System;
using Badminton_Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badminton_UnitTest
{
    [TestClass]
    public class UnitTestTeam
    {
        private Team testTeam = new Team("Test Hold");

        [TestMethod]
        //Makes sure testTeam is not null
        public void TestMethod1()
        {
            try
            {
                Assert.IsNotNull(testTeam.Name);
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure Team cant be created with nulls
        public void TestMethod2()
        {
            try
            {
                Team testTeamTwo = new Team(null);
                Assert.IsNotNull(testTeamTwo.Name);
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure name cant be ""
        public void TestMethod3()
        {
            try
            {
                testTeam.Name = "";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure name cant be null
        public void TestMethod4()
        {
            try
            {
                testTeam.Name = null;
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests name lower limit
        public void TestMethod5()
        {
            try
            {
                testTeam.Name = "A";

                Assert.AreEqual("A", testTeam.Name);
            }
            catch (ArgumentException ae)
            {
                Assert.Fail("Argument exception expected");
            }
        }
    }
}
