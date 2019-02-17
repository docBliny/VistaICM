using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for ListenerTest and is intended
    ///to contain all ListenerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ListenerTest
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
        ///A test for OnDataReceived
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnDataReceivedTest()
        {
            bool eventRaised = false;
            PrivateObject param0 = new PrivateObject(typeof(ListenerSubClass));
            Listener_Accessor target = new Listener_Accessor(param0);
            DataReceivedEventArgs e = new DataReceivedEventArgs(new byte[] {});

            target.add_DataReceived(delegate { eventRaised = true; });
            target.OnDataReceived(e);

            Assert.IsTrue(eventRaised);
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void InitializeComponentTest()
        {
            PrivateObject param0 = new PrivateObject(typeof(ListenerSubClass));
            Listener_Accessor target = new Listener_Accessor(param0);
            target.InitializeComponent();
            Assert.IsNotNull(target.Components);
        }

    }
}
