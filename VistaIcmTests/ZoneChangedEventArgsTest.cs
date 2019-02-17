using System;
using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for ZoneChangedEventArgsTest and is intended
    ///to contain all ZoneChangedEventArgsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ZoneChangedEventArgsTest
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
        ///A test for Zone
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ZoneTest()
        {
            // Create bogus zone for constructor
            PrivateObject param0 = new PrivateObject(new ZoneChangedEventArgs(new Zone()));
            ZoneChangedEventArgs_Accessor target = new ZoneChangedEventArgs_Accessor(param0);

            // Create the actual object instance we want to test with
            Zone expected = new Zone();
            Zone actual;

            target.Zone = expected;
            actual = target.Zone;
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        ///A test for ZoneChangedEventArgs Constructor
        ///</summary>
        [TestMethod()]
        public void ZoneChangedEventArgsConstructorTest()
        {
            Zone zone = new Zone();
            ZoneChangedEventArgs target = new ZoneChangedEventArgs(zone);
            Assert.AreSame(zone, target.Zone);
        }

        /// <summary>
        ///A test for ZoneChangedEventArgs Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZoneChangedEventArgsConstructorNullTest()
        {
            ZoneChangedEventArgs target = new ZoneChangedEventArgs(null);
            Assert.Fail("No exception raised.");
        }
    }
}
