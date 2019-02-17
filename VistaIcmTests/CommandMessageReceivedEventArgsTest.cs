using System;
using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for CommandMessageReceivedEventArgsTest and is intended
    ///to contain all CommandMessageReceivedEventArgsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandMessageReceivedEventArgsTest
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
        ///A test for CommandMessageReceivedEventArgs Constructor
        ///</summary>
        [TestMethod()]
        public void CommandMessageReceivedEventArgsConstructorTest()
        {
            CommandMessage message = new CommandMessage();
            CommandMessageReceivedEventArgs target = new CommandMessageReceivedEventArgs(message);
            Assert.AreSame(message, target.Message);
        }

        /// <summary>
        ///A test for CommandMessageReceivedEventArgs Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CommandMessageReceivedEventArgsConstructorNullTest()
        {
            CommandMessageReceivedEventArgs target = new CommandMessageReceivedEventArgs(null);
            Assert.Fail("No exception raised.");
        }
    }
}
