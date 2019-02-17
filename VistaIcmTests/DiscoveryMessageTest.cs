using System;
using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.NetworkInformation;

namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for DiscoveryMessageTest and is intended
    ///to contain all DiscoveryMessageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DiscoveryMessageTest
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
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            DiscoveryMessage target = new DiscoveryMessage();
            string expected = "Changed value";
            string actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MacAddress
        ///</summary>
        [TestMethod()]
        public void MacAddressTest()
        {
            DiscoveryMessage target = new DiscoveryMessage();
            PhysicalAddress expected = new PhysicalAddress(new byte[] { 00, 01, 02, 03, 04 });
            PhysicalAddress actual;
            target.MacAddress = expected;
            actual = target.MacAddress;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            DiscoveryMessage target = new DiscoveryMessage();
            string expected = "key";
            string actual;
            target.Key = expected;
            actual = target.Key;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyNullTest()
        {
            DiscoveryMessage target = new DiscoveryMessage();
            target.Key = null;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyNull2Test()
        {
            DiscoveryMessage target = new DiscoveryMessage();
            target.Key = "";
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for IPAddress
        ///</summary>
        [TestMethod()]
        public void IPAddressTest()
        {
            DiscoveryMessage target = new DiscoveryMessage();
            IPAddress expected = new IPAddress(new byte[] { 001, 002, 003, 004 });
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
            DiscoveryMessage target = new DiscoveryMessage();
            int expected = 0xbeef;
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
            DiscoveryMessage target = new DiscoveryMessage();
            string actual = target.ToString();
            Assert.IsFalse(actual.Length == 0);
            Assert.IsTrue(actual.StartsWith("{"), "Didn't start with '{'");
            Assert.IsTrue(actual.EndsWith("}"), "Didn't end with '}'");
        }

        /// <summary>
        ///A test for DiscoveryMessage Constructor
        ///</summary>
        [TestMethod()]
        public void DiscoveryMessageConstructorTest()
        {
            DiscoveryMessage target = new DiscoveryMessage();
            Assert.AreEqual(0, target.Checksum);
            Assert.AreEqual(null, target.IPAddress);
            Assert.AreEqual(string.Empty, target.Key);
            Assert.AreEqual(null, target.MacAddress);
            Assert.AreEqual(string.Empty, target.Value);
        }
    }
}
