using System.Net.NetworkInformation;
using Blinnikka.VistaIcm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Timers;
using System;
using System.Collections.Generic;

namespace VistaIcmTests
{
    
    
    /// <summary>
    ///This is a test class for SecurityModuleTest and is intended
    ///to contain all SecurityModuleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SecurityModuleTest
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
        ///A test for Zones
        ///</summary>
        [TestMethod()]
        public void ZonesTest()
        {
            SecurityModule target = null;
            try
            {
                target = new SecurityModule();
                SortedList<int, Zone> actual;
                actual = target.Zones;
                Assert.AreEqual(16, actual.Count);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for RefreshInterval
        ///</summary>
        [TestMethod()]
        public void RefreshIntervalTest()
        {
            SecurityModule target = null;
            try
            {
                target = new SecurityModule();
                int expected = 30 * 1000;
                int actual;
                target.RefreshInterval = expected;
                actual = target.RefreshInterval;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for RefreshInterval
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RefreshIntervalRangeTest()
        {
            SecurityModule target = null;
            try
            {
                target = new SecurityModule();
                target.RefreshInterval = 0;
                Assert.Fail("No exception raised.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for Ready
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ReadyTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor(new IPAddress(new byte[] { 192, 168, 000, 001 }));
                bool expected = true;
                bool actual;
                target.Ready = expected;
                actual = target.Ready;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for Ready
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ReadyEventTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor(new IPAddress(new byte[] {192, 168, 000, 001}));
                target.add_ReadyChanged(delegate { eventRaised = true; });
                target.Ready = true;
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for IPAddress
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void IPAddressTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                IPAddress expected = new IPAddress(new byte[] {192, 168, 000, 002});
                IPAddress actual;
                target.IPAddress = expected;
                actual = target.IPAddress;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void IdTest1()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                int expected = 4;
                int actual;
                target.Id = expected;
                actual = target.Id;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for Display
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void DisplayTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                string expected = "  ***DISPLAY*** ";
                string actual;
                target.Display = expected;
                actual = target.Display;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for Display
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void DisplayEventTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_DisplayChanged(delegate { eventRaised = true; });
                target.Display = "  ***DISPLAY*** ";
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ArmStatus
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ArmStatusTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                ArmStatus expected = ArmStatus.ArmedStay;
                ArmStatus actual;
                target.ArmStatus = expected;
                actual = target.ArmStatus;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ArmStatus
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ArmStatusEventTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_ArmStatusChanged(delegate { eventRaised = true; });
                target.ArmStatus = ArmStatus.ArmedAway;
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for AlarmState
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void AlarmStateTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                AlarmState expected = AlarmState.Alarm;
                AlarmState actual;
                target.AlarmState = expected;
                actual = target.AlarmState;
                Assert.AreEqual(expected, actual);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for AlarmState
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void AlarmStateEventTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_AlarmStateChanged(delegate { eventRaised = true; });
                target.AlarmState = AlarmState.Fire;
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for zone_NameChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void zone_NameChangedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_ZoneChanged(delegate { eventRaised = true; });
                target.Zones[0].Name = "Changed";
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for zone_IsFaultedChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void zone_IsFaultedChangedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_ZoneChanged(delegate { eventRaised = true; });
                target.Zones[0].IsFaulted = true;
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ToUInt16
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ToUInt16Test()
        {
            byte[] data = new byte[] { 0, 0xFF };
            int index = 0;
            ushort expected = 0xFF;
            ushort actual;
            actual = SecurityModule_Accessor.ToUInt16(data, index);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToUInt16
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ToUInt162Test()
        {
            byte[] data = new byte[] { 0xFF, 0 };
            int index = 0;
            ushort expected = 0xFF00;
            ushort actual;
            actual = SecurityModule_Accessor.ToUInt16(data, index);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Stop
        ///</summary>
        [TestMethod()]
        public void StopTest()
        {
            SecurityModule target = null;
            try
            {
                target = new SecurityModule();
                target.Stop();
                Assert.Inconclusive("TODO: Need mock listener to verify functionality.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            SecurityModule target = null;
            try
            {
                target = new SecurityModule();
                target.Start();
                Assert.Inconclusive("TODO: Need mock listener to verify functionality.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SetZoneStatus
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void SetZoneStatusTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_ZoneChanged(delegate { eventRaised = true; });
                string key = "ZS.16";
                string value = "1";
                target.SetZoneStatus(key, value);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SetReady
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void SetReadyTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor(new IPAddress(new byte[] {192, 168, 000, 003}));
                target.add_ReadyChanged(delegate { eventRaised = true; });
                string value = "1";
                target.SetReady(value);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SetFireEvent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void SetFireEventTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_AlarmStateChanged(delegate { eventRaised = true; });
                target.SetFireEvent("1");
                Assert.IsTrue(eventRaised);
                Assert.AreEqual(AlarmState.Fire, target.AlarmState);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SetArmStatus
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void SetArmStatusTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor(new IPAddress(new byte[] {192, 168, 000, 004}));
                string value = "2";
                target.add_ArmStatusChanged(delegate { eventRaised = true; });
                target.SetArmStatus(value);
                Assert.IsTrue(eventRaised);
                Assert.AreEqual(ArmStatus.ArmedAway, target.ArmStatus);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SetAlarmEvent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void SetAlarmEventTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_AlarmStateChanged(delegate { eventRaised = true; });
                target.SetAlarmEvent("1");
                Assert.IsTrue(eventRaised);
                Assert.AreEqual(AlarmState.Alarm, target.AlarmState);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for Refresh
        ///</summary>
        [TestMethod()]
        public void RefreshTest()
        {
            SecurityModule target = null;
            try
            {
                target = new SecurityModule();
                //target.Refresh();
                Assert.Inconclusive("TODO: Cannot test without a mock object and listener.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessVariablePacket
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessVariablePacketTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor(new IPAddress(new byte[] {192, 168, 000, 005}));
                byte[] data = new byte[] {};
                target.ProcessVariablePacket(data);
                Assert.Inconclusive("TODO: Need to simulate data packet.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessVariableMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessVariableMessageTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor(new IPAddress(new byte[] {192, 168, 000, 006}));
                VariableMessage message = new VariableMessage();
                message.Key = "Ready";
                message.Node = 1;
                message.Unit = 1;
                message.Value = "1";
                target.ProcessVariableMessage(message);
                Assert.AreEqual(true, target.Ready);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessUnitInfoPacket
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessUnitInfoPacketTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor(new IPAddress(new byte[] {192, 168, 000, 007}));
                byte[] data = new byte[] { };
                target.ProcessUnitInfoPacket(data);
                Assert.Inconclusive("TODO: Need to simulate data packet.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessUnitInfoMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessUnitInfoMessageTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                UnitInfoMessage message = new UnitInfoMessage();
                message.Checksum = 12345;
                message.IPAddress = new IPAddress(new byte[] {127, 0, 0, 1});
                message.MacAddress = new PhysicalAddress(new byte[] {192, 168, 0, 1});
                message.Number = 6;
                message.Variables.Add("name", "Security");
                message.Variables.Add("T.1", "MyZoneName1");
                target.ProcessUnitInfoMessage(message);
                Assert.AreEqual("MyZoneName1", target.Zones[0].Name);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessDiscoveryPacket
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessDiscoveryPacketTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                byte[] data = new byte[] { };
                target.ProcessDiscoveryPacket(data);
                Assert.Inconclusive("TODO: Need to simulate data packet.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessDiscoveryMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessDiscoveryMessageTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                DiscoveryMessage message = new DiscoveryMessage();
                message.Checksum = 4321;
                message.IPAddress = new IPAddress(new byte[] {127, 0, 0, 1});
                message.Key = "sbrnd";
                message.Value = "Honeywell";
                message.MacAddress = new PhysicalAddress(new byte[] {192, 168, 0, 1});
                target.add_DiscoveryCompleted(delegate { eventRaised = true; });

                target.ProcessDiscoveryMessage(message);
                Assert.AreEqual(new IPAddress(new byte[] {127, 0, 0, 1}), target.IPAddress);
                Assert.AreEqual(new PhysicalAddress(new byte[] {192, 168, 0, 1}), target.MacAddress);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandPacket
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandPacketTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                byte[] data = new byte[] {};
                target.ProcessCommandPacket(data);
                Assert.Inconclusive("TODO: Need to simulate data packet.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandMessageAlarmTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                CommandMessage message = new CommandMessage();
                message.Name = "Security";
                message.Parameter1 = "Alarm";
                message.Parameter2 = "";
                message.Parameter3 = "";
                target.add_AlarmStateChanged(delegate { eventRaised = true; });
                target.ProcessCommandMessage(message);
                Assert.IsTrue(eventRaised);
                Assert.AreEqual(AlarmState.Alarm, target.AlarmState);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandMessageArmedAwayTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                CommandMessage message = new CommandMessage();
                message.Name = "Security";
                message.Parameter1 = "Armed Away";
                message.Parameter2 = "";
                message.Parameter3 = "";
                target.add_ArmStatusChanged(delegate { eventRaised = true; });
                target.ProcessCommandMessage(message);
                Assert.IsTrue(eventRaised);
                Assert.AreEqual(ArmStatus.ArmedAway, target.ArmStatus);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandMessageArmedStayTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                CommandMessage message = new CommandMessage();
                message.Name = "Security";
                message.Parameter1 = "Armed Stay";
                message.Parameter2 = "";
                message.Parameter3 = "";
                target.add_ArmStatusChanged(delegate { eventRaised = true; });
                target.ProcessCommandMessage(message);
                Assert.IsTrue(eventRaised);
                Assert.AreEqual(ArmStatus.ArmedStay, target.ArmStatus);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandMessageDisarmedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                CommandMessage message = new CommandMessage();
                message.Name = "Security";
                message.Parameter1 = "Disarmed";
                message.Parameter2 = "";
                message.Parameter3 = "";
                target.ArmStatus = ArmStatus.ArmedAway;
                target.add_ArmStatusChanged(delegate { eventRaised = true; });
                target.ProcessCommandMessage(message);
                Assert.IsTrue(eventRaised);
                Assert.AreEqual(ArmStatus.Disarmed, target.ArmStatus);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandMessageFireTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                CommandMessage message = new CommandMessage();
                message.Name = "Security";
                message.Parameter1 = "Fire";
                message.Parameter2 = "";
                message.Parameter3 = "";
                target.add_AlarmStateChanged(delegate { eventRaised = true; });
                target.ProcessCommandMessage(message);
                Assert.IsTrue(eventRaised);
                Assert.AreEqual(AlarmState.Fire, target.AlarmState);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandMessageLowBatteryTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                CommandMessage message = new CommandMessage();
                message.Name = "Security";
                message.Parameter1 = "Low Battery";
                message.Parameter2 = "";
                message.Parameter3 = "";
                target.add_LowBattery(delegate { eventRaised = true; });
                target.ProcessCommandMessage(message);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandMessagePowerFailureTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                CommandMessage message = new CommandMessage();
                message.Name = "Security";
                message.Parameter1 = "Power Failure";
                message.Parameter2 = "";
                message.Parameter3 = "";
                target.add_PowerFailure(delegate { eventRaised = true; });
                target.ProcessCommandMessage(message);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for ProcessCommandMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void ProcessCommandMessagePowerRestoredTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                CommandMessage message = new CommandMessage();
                message.Name = "Security";
                message.Parameter1 = "Power Returned";
                message.Parameter2 = "";
                message.Parameter3 = "";
                target.add_PowerRestored(delegate { eventRaised = true; });
                target.ProcessCommandMessage(message);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnZoneChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnZoneChangedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                Zone zone = new Zone();
                target.add_ZoneChanged(delegate { eventRaised = true; });
                target.OnZoneChanged(zone);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnVariableMessageReceived
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnVariableMessageReceivedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                VariableMessage message = new VariableMessage();
                target.add_VariableMessageReceived(delegate { eventRaised = true; });
                target.OnVariableMessageReceived(message);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnUnitInfoMessageReceived
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnUnitInfoMessageReceivedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                UnitInfoMessage message = new UnitInfoMessage();
                target.add_UnitInfoMessageReceived(delegate { eventRaised = true; });
                target.OnUnitInfoMessageReceived(message);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnReadyChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnReadyChangedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_ReadyChanged(delegate { eventRaised = true; });
                target.OnReadyChanged();
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnPowerRestored
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnPowerRestoredTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_PowerRestored(delegate { eventRaised = true; });
                target.OnPowerRestored();
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnPowerFailure
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnPowerFailureTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_PowerFailure(delegate { eventRaised = true; });
                target.OnPowerFailure();
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnLowBattery
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnLowBatteryTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_LowBattery(delegate { eventRaised = true; });
                target.OnLowBattery();
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnDisplayChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnDisplayChangedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_DisplayChanged(delegate { eventRaised = true; });
                target.OnDisplayChanged();
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnDiscoveryMessageReceived
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnDiscoveryMessageReceivedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_DiscoveryMessageReceived(delegate { eventRaised = true; });
                DiscoveryMessage message = new DiscoveryMessage();
                target.OnDiscoveryMessageReceived(message);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnDiscoveryCompleted
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnDiscoveryCompletedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_DiscoveryCompleted(delegate { eventRaised = true; });
                target.OnDiscoveryCompleted();
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnCommandMessageReceived
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnCommandMessageReceivedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_CommandMessageReceived(delegate { eventRaised = true; });
                CommandMessage message = new CommandMessage();
                target.OnCommandMessageReceived(message);
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnArmStatusChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnArmStatusChangedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_ArmStatusChanged(delegate { eventRaised = true; });
                target.OnArmStatusChanged();
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for OnAlarmStateChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void OnAlarmStateChangedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                bool eventRaised = false;
                target = new SecurityModule_Accessor();
                target.add_AlarmStateChanged(delegate { eventRaised = true; });
                target.OnAlarmStateChanged();
                Assert.IsTrue(eventRaised);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for _listener_DataReceived
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Blinnikka.VistaIcm.dll")]
        public void _listener_DataReceivedTest()
        {
            SecurityModule_Accessor target = null;
            try
            {
                target = new SecurityModule_Accessor();
                object sender = null;
                DataReceivedEventArgs e = new DataReceivedEventArgs(new byte[] {});
                target._listener_DataReceived(sender, e);
                Assert.Inconclusive("TODO: Need test data packet.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SecurityModule Constructor
        ///</summary>
        [TestMethod()]
        public void SecurityModuleConstructorTest3()
        {
            SecurityModule target = null;
            try
            {
                IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
                target = new SecurityModule(ipAddress);
                Assert.AreEqual(ipAddress, target.IPAddress);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SecurityModule Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SecurityModuleConstructorNullTest3()
        {
            SecurityModule target = null;
            try
            {
                IPAddress ipAddress = null;
                target = new SecurityModule(ipAddress);
                Assert.Fail("No exception raised.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SecurityModule Constructor
        ///</summary>
        [TestMethod()]
        public void SecurityModuleConstructorTest2()
        {
            SecurityModule target = null;
            try
            {
                target = new SecurityModule();

                // Verify initial state
                Assert.AreEqual(AlarmState.NoAlarm, target.AlarmState);
                Assert.AreEqual(ArmStatus.Disarmed, target.ArmStatus);
                Assert.AreEqual(string.Empty, target.Display);
                Assert.AreEqual(0, target.Id);
                Assert.AreEqual(null, target.IPAddress);
                Assert.AreEqual(null, target.MacAddress);
                Assert.AreEqual(false, target.Ready);
                Assert.AreEqual(5000, target.RefreshInterval);
                Assert.AreEqual(16, target.Zones.Count);
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SecurityModule Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SecurityModuleConstructorNullTest1()
        {
            SecurityModule target = null;
            try
            {
                IPAddress ipAddress = null;
                Listener listener = new UdpListener();
                target = new SecurityModule(ipAddress, listener);
                Assert.Fail("No exception raised.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SecurityModule Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SecurityModuleConstructorNullTest2()
        {
            SecurityModule target = null;
            try
            {
                IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
                Listener listener = null;
                target = new SecurityModule(ipAddress, listener);
                Assert.Fail("No exception raised.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

        /// <summary>
        ///A test for SecurityModule Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SecurityModuleConstructorNullTest()
        {
            SecurityModule target = null;
            try
            {
                Listener listener = null;
                target = new SecurityModule(listener);
                Assert.Fail("No exception raised.");
            }
            finally
            {
                if(target != null) { target.Dispose(); }
            }
        }

    }
}
