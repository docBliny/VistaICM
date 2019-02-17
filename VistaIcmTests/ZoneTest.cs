using System;
using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for ZoneTest and is intended
    ///to contain all ZoneTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ZoneTest
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
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            Zone target = new Zone();
            string expected = "Test name";
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameNullTest()
        {
            Zone target = new Zone();
            target.Name = null;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for NameChanged
        ///</summary>
        [TestMethod()]
        public void NameChangedTest()
        {
            Zone target = new Zone();
            bool eventRaised = false;
            target.NameChanged += delegate { eventRaised = true; };
            target.Name = "Changed";
            Assert.IsTrue(eventRaised);
        }

        /// <summary>
        ///A test for IsFaulted
        ///</summary>
        [TestMethod()]
        public void IsFaultedTest()
        {
            Zone target = new Zone();
            bool expected = true;
            bool actual;
            target.IsFaulted = expected;
            actual = target.IsFaulted;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsFaultedChanged
        ///</summary>
        [TestMethod()]
        public void IsFaultedChangedTest()
        {
            Zone target = new Zone();
            bool eventRaised = false;
            target.IsFaultedChanged += delegate { eventRaised = true; };
            target.IsFaulted = true;
            Assert.IsTrue(eventRaised);
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            Zone target = new Zone();
            int expected = 16;
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IdRange1Test()
        {
            Zone target = new Zone();
            target.Id = 0;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IdRange2Test()
        {
            Zone target = new Zone();
            target.Id = 17;
            Assert.Fail("No exception raised.");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Zone target = new Zone();
            string actual = target.ToString();
            Assert.IsFalse(actual.Length == 0);
            Assert.IsTrue(actual.StartsWith("{"), "Didn't start with '{'");
            Assert.IsTrue(actual.EndsWith("}"), "Didn't end with '}'");
        }

        /// <summary>
        ///A test for OnNameChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnNameChangedTest()
        {
            bool eventRaised = false;
            Zone_Accessor target = new Zone_Accessor();
            target.add_NameChanged(delegate { eventRaised = true;});
            target.OnNameChanged();
            Assert.IsTrue(eventRaised);
        }

        /// <summary>
        ///A test for OnIsFaultedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnIsFaultedChangedTest()
        {
            bool eventRaised = false;
            Zone_Accessor target = new Zone_Accessor();
            target.add_IsFaultedChanged(delegate { eventRaised = true; });
            target.OnIsFaultedChanged();
            Assert.IsTrue(eventRaised);
        }

        /// <summary>
        ///A test for Zone Constructor
        ///</summary>
        [TestMethod()]
        public void ZoneConstructorTest()
        {
            Zone target = new Zone();

            // Check initial values
            Assert.AreEqual(0, target.Id);
            Assert.AreEqual(false, target.IsFaulted);
            Assert.AreEqual(string.Empty, target.Name);
        }
    }
}
