using System;
using System.Diagnostics;
using Badminton_Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badminton_UnitTest
{
    [TestClass]
    public class UnitTestMember
    {
        private Member testMember = new Member("Bobjones", "Jensen", "1234", "1234567891", "Andevej 1", "1234", "12345678",
            "bobjones@mail.dk");

        [TestMethod]
        //Makes sure testMember is not null
        public void TestMethod1()
        {
            Assert.IsNotNull(testMember);
        }

        [TestMethod]
        //Makes sure Member cant be created with nulls
        public void TestMethod31()
        {
            try
            {
                Member testMemberTwo = new Member(null, "Jensen", "1234", "1234567891", "Andevej 1", "1234", "12345678",
                    "bobjones@mail.dk");
                Assert.IsNotNull(testMemberTwo.FirstName);
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure firstname cant be ""
        public void TestMethod2()
        {
            try
            {
                testMember.FirstName = "";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure firstname cant be null
        public void TestMethod3()
        {
            try
            {
                testMember.FirstName = null;
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests firstname lower limit
        public void TestMethod4()
        {
            try
            {
                testMember.FirstName = "A";

                Assert.AreEqual("A", testMember.FirstName);
            }
            catch (ArgumentException ae)
            {
                Assert.Fail("Argument exception expected");
            }
        }

        [TestMethod]
        //Makes sure surname cant be ""
        public void TestMethod5()
        {
            try
            {
                testMember.SurName = "";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure surname cant be null
        public void TestMethod6()
        {
            try
            {
                testMember.SurName = null;
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests surname lower limit
        public void TestMethod7()
        {
            try
            {
                testMember.SurName = "A";

                Assert.AreEqual("A", testMember.SurName);
            }
            catch (ArgumentException ae)
            {
                Assert.Fail("Argument exception expected");
            }
        }

        [TestMethod]
        //Makes sure cpr cant be ""
        public void TestMethod8()
        {
            try
            {
                testMember.Cpr = "";
                Assert.Fail("Argument exception expected");
            }
            catch (Exception)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure cpr cant be null
        public void TestMethod9()
        {
            try
            {
                testMember.Cpr = null;
                Assert.Fail("Argument exception expected");
            }
            catch (Exception)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests cpr can be set
        public void TestMethod10()
        {
            try
            {
                testMember.Cpr = "1111111111";

                Assert.AreEqual("1111111111", testMember.Cpr);
            }
            catch (ArgumentException ae)
            {
                Assert.Fail("Argument exception expected");
            }
        }

        [TestMethod]
        //Tests cpr lower limit
        public void TestMethod11()
        {
            try
            {
                testMember.Cpr = "123456789";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests cpr upper limit
        public void TestMethod12()
        {
            try
            {
                testMember.Cpr = "12345678912";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure address cant be ""
        public void TestMethod13()
        {
            try
            {
                testMember.Address = "";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure address cant be null
        public void TestMethod14()
        {
            try
            {
                testMember.Address = null;
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests address lower limit
        public void TestMethod15()
        {
            try
            {
                testMember.Address = "A";

                Assert.AreEqual("A", testMember.Address);
            }
            catch (ArgumentException ae)
            {
                Assert.Fail("Argument exception expected");
            }
        }

        [TestMethod]
        //Makes sure zipCode cant be ""
        public void TestMethod16()
        {
            try
            {
                testMember.ZipCode = "";
                Assert.Fail("Argument exception expected");
            }
            catch (Exception)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure zipCode cant be null
        public void TestMethod17()
        {
            try
            {
                testMember.ZipCode = null;
                Assert.Fail("Argument exception expected");
            }
            catch (Exception)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests zipCode can be set
        public void TestMethod18()
        {
            try
            {
                testMember.ZipCode = "4321";

                Assert.AreEqual("4321", testMember.ZipCode);
            }
            catch (ArgumentException ae)
            {
                Assert.Fail("Argument exception expected");
            }
        }

        [TestMethod]
        //Tests zipCode lower limit
        public void TestMethod19()
        {
            try
            {
                testMember.Cpr = "123";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests zipCode upper limit
        public void TestMethod20()
        {
            try
            {
                testMember.Cpr = "12345";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure phone cant be ""
        public void TestMethod21()
        {
            try
            {
                testMember.Phone = "";
                Assert.Fail("Argument exception expected");
            }
            catch (Exception)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure phone cant be null
        public void TestMethod22()
        {
            try
            {
                testMember.Phone = null;
                Assert.Fail("Argument exception expected");
            }
            catch (Exception)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests phone can be set
        public void TestMethod23()
        {
            try
            {
                testMember.Phone = "11111111";

                Assert.AreEqual("11111111", testMember.Phone);
            }
            catch (ArgumentException ae)
            {
                Assert.Fail("Argument exception expected");
            }
        }

        [TestMethod]
        //Tests phone lower limit
        public void TestMethod24()
        {
            try
            {
                testMember.Cpr = "1234567";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Tests phone upper limit
        public void TestMethod25()
        {
            try
            {
                testMember.Cpr = "123456789";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure mail cant be ""
        public void TestMethod26()
        {
            try
            {
                testMember.Mail = "";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure mail cant be null
        public void TestMethod27()
        {
            try
            {
                testMember.Mail = null;
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure mail can be set
        public void TestMethod28()
        {
            try
            {
                testMember.Mail = "fisk@test.com";

                Assert.AreEqual("fisk@test.com", testMember.Mail);
                
            }
            catch (ArgumentException ae)
            {
                Assert.Fail("Argument exception expected");
            }
        }

        [TestMethod]
        //Makes sure mail cant be wrong format
        public void TestMethod29()
        {
            try
            {
                testMember.Mail = "fisk@testcom";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }

        [TestMethod]
        //Makes sure mail cant be wrong format
        public void TestMethod30()
        {
            try
            {
                testMember.Mail = "fisktest.com";
                Assert.Fail("Argument exception expected");
            }
            catch (ArgumentException ae)
            {
                //ok
            }
        }
    }
}
