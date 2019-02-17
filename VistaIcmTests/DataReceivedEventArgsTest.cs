using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for DataReceivedEventArgsTest and is intended
    ///to contain all DataReceivedEventArgsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataReceivedEventArgsTest
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
        ///A test for Data
        ///</summary>
        [TestMethod()]
        public void DataTest()
        {
            byte[] data = new byte[] {0, 1};
            DataReceivedEventArgs target = new DataReceivedEventArgs(data);
            byte[] actual;
            actual = target.GetData();
            Assert.AreEqual(0x01, actual[1]);
        }

        /// <summary>
        ///A test for DataReceivedEventArgs Constructor
        ///</summary>
        [TestMethod()]
        public void DataReceivedEventArgsConstructorTest()
        {
            byte[] data = new byte[] { 1,2,3 };
            DataReceivedEventArgs target = new DataReceivedEventArgs(data);
            Assert.AreEqual(0x03, target.GetData()[2]);
        }
    }
}
