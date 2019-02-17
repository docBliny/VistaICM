using System;
using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for VariableMessageReceivedEventArgsTest and is intended
    ///to contain all VariableMessageReceivedEventArgsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VariableMessageReceivedEventArgsTest
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
        ///A test for VariableMessageReceivedEventArgs Constructor
        ///</summary>
        [TestMethod()]
        public void VariableMessageReceivedEventArgsConstructorTest()
        {
            VariableMessage message = new VariableMessage();
            VariableMessageReceivedEventArgs target = new VariableMessageReceivedEventArgs(message);
            Assert.AreSame(message, target.Message);
        }

        /// <summary>
        ///A test for VariableMessageReceivedEventArgs Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VariableMessageReceivedEventArgsConstructorNullTest()
        {
            VariableMessageReceivedEventArgs target = new VariableMessageReceivedEventArgs(null);
            Assert.Fail("No exception raised.");
        }
    }
}
