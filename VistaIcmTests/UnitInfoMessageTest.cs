using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for UnitInfoMessageTest and is intended
    ///to contain all UnitInfoMessageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UnitInfoMessageTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Variables
        ///</summary>
        [TestMethod()]
        public void VariablesTest()
        {
            UnitInfoMessage target = new UnitInfoMessage();
            SortedList<string, string> expected = new SortedList<string, string>();
            SortedList<string, string> actual;
            target.Variables = expected;
            actual = target.Variables;
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        ///A test for Number
        ///</summary>
        [TestMethod()]
        public void NumberTest()
        {
            UnitInfoMessage target = new UnitInfoMessage();
            int expected = 1;
            int actual;
            target.Number = expected;
            actual = target.Number;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MacAddress
        ///</summary>
        [TestMethod()]
        public void MacAddressTest()
        {
            UnitInfoMessage target = new UnitInfoMessage();
            PhysicalAddress expected = new PhysicalAddress(new byte[] {00, 01, 02, 03, 04});
            PhysicalAddress actual;
            target.MacAddress = expected;
            actual = target.MacAddress;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IPAddress
        ///</summary>
        [TestMethod()]
        public void IPAddressTest()
        {
            UnitInfoMessage target = new UnitInfoMessage();
            IPAddress expected = new IPAddress(new byte[] {001, 002, 003, 004});
            IPAddress actual;
            target.IPAddress = expected;
            actual = target.IPAddress;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Checksum
        ///</summary>
        [TestMethod()]
        public void ChecksumTest()
        {
            UnitInfoMessage target = new UnitInfoMessage();
            int expected = 0xf00d;
            int actual;
            target.Checksum = expected;
            actual = target.Checksum;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            UnitInfoMessage target = new UnitInfoMessage();
            string actual = target.ToString();
            Assert.IsFalse(actual.Length == 0);
            Assert.IsTrue(actual.StartsWith("{"), "Didn't start with '{'");
            Assert.IsTrue(actual.EndsWith("}"), "Didn't end with '}'");
        }

        /// <summary>
        ///A test for UnitInfoMessage Constructor
        ///</summary>
        [TestMethod()]
        public void UnitInfoMessageConstructorTest()
        {
            UnitInfoMessage target = new UnitInfoMessage();
            
            // Check initial values
            Assert.AreEqual(0, target.Checksum);
            Assert.AreEqual(null, target.IPAddress);
            Assert.AreEqual(null, target.MacAddress);
            Assert.AreEqual(0, target.Number);
            Assert.IsNotNull(target.Variables);
        }
    }
}
