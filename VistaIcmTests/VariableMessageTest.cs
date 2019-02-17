using System;
using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for VariableMessageTest and is intended
    ///to contain all VariableMessageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VariableMessageTest
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
            VariableMessage target = new VariableMessage();
            string expected = "New value";
            string actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValueNullTest()
        {
            VariableMessage target = new VariableMessage();
            target.Value = null;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for Unit
        ///</summary>
        [TestMethod()]
        public void UnitTest()
        {
            VariableMessage target = new VariableMessage();
            int expected = 2;
            int actual;
            target.Unit = expected;
            actual = target.Unit;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Node
        ///</summary>
        [TestMethod()]
        public void NodeTest()
        {
            VariableMessage target = new VariableMessage();
            int expected = 3;
            int actual;
            target.Node = expected;
            actual = target.Node;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Key
        ///</summary>
        [TestMethod()]
        public void KeyTest()
        {
            VariableMessage target = new VariableMessage();
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
            VariableMessage target = new VariableMessage();
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
            VariableMessage target = new VariableMessage();
            target.Key = "";
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            VariableMessage target = new VariableMessage();
            string actual = target.ToString();
            Assert.IsFalse(actual.Length == 0);
            Assert.IsTrue(actual.StartsWith("{"), "Didn't start with '{'");
            Assert.IsTrue(actual.EndsWith("}"), "Didn't end with '}'");
        }

        /// <summary>
        ///A test for VariableMessage Constructor
        ///</summary>
        [TestMethod()]
        public void VariableMessageConstructorTest()
        {
            VariableMessage target = new VariableMessage();
            Assert.AreEqual(string.Empty, target.Key);
            Assert.AreEqual(0, target.Node);
            Assert.AreEqual(0, target.Unit);
            Assert.AreEqual(string.Empty, target.Value);
        }
    }
}
