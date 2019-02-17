using System;
using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for CommandMessageTest and is intended
    ///to contain all CommandMessageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandMessageTest
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
        ///A test for Parameter3
        ///</summary>
        [TestMethod()]
        public void Parameter3Test()
        {
            CommandMessage target = new CommandMessage();
            string expected = "param3";
            string actual;
            target.Parameter3 = expected;
            actual = target.Parameter3;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Parameter3
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parameter3NullTest()
        {
            CommandMessage target = new CommandMessage();
            target.Parameter3 = null;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for Parameter2
        ///</summary>
        [TestMethod()]
        public void Parameter2Test()
        {
            CommandMessage target = new CommandMessage();
            string expected = "param2";
            string actual;
            target.Parameter2 = expected;
            actual = target.Parameter2;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Parameter2
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parameter2NullTest()
        {
            CommandMessage target = new CommandMessage();
            target.Parameter2 = null;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for Parameter1
        ///</summary>
        [TestMethod()]
        public void Parameter1Test()
        {
            CommandMessage target = new CommandMessage();
            string expected = "param1";
            string actual;
            target.Parameter1 = expected;
            actual = target.Parameter1;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Parameter1
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parameter1NullTest()
        {
            CommandMessage target = new CommandMessage();
            target.Parameter1 = null;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            CommandMessage target = new CommandMessage();
            string expected = "The name";
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Parameter1
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameNullTest()
        {
            CommandMessage target = new CommandMessage();
            target.Name = null;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            CommandMessage target = new CommandMessage();
            string actual = target.ToString();
            Assert.IsFalse(actual.Length == 0);
            Assert.IsTrue(actual.StartsWith("{"), "Didn't start with '{'");
            Assert.IsTrue(actual.EndsWith("}"), "Didn't end with '}'");
        }

        /// <summary>
        ///A test for CommandMessage Constructor
        ///</summary>
        [TestMethod()]
        public void CommandMessageConstructorTest()
        {
            CommandMessage target = new CommandMessage();
            Assert.AreEqual(string.Empty, target.Name);
            Assert.AreEqual(string.Empty, target.Parameter1);
            Assert.AreEqual(string.Empty, target.Parameter2);
            Assert.AreEqual(string.Empty, target.Parameter3);
        }
    }
}
