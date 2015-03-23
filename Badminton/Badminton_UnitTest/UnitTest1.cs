using System;
using Badminton_Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badminton_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Member testMember = new Member(true, "Bobjones", "Jensen", "1234567891", "Andevej 1", "1234", "12345678", "bobjones@mail.dk");

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(testMember);
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                testMember.FirstName = null;
                Assert.Fail("Argument exception expected");
            }
            catch (Exception)
            {
                //ok
            }
        }
    }
}
