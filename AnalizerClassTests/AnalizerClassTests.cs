using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnalizerClassLibrary.Tests
{
    [TestClass]
    public class AnalizerClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void EstimateTest1_Error07()
        {
            //Arrange
            string expected = "&Error 07 — Дуже довгий вираз. Максимальная довжина — 65536 символів.";
            AnalizerClass.expression = new string('9', 65537);

            //Actual
            string actualResult = AnalizerClass.Format();

            //Assert
            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "data.xml", "ValidData", DataAccessMethod.Sequential)]
        public void EstimateTest2_ValidData()
        {
            //Arrange
            string expected = Convert.ToString(TestContext.DataRow["expected"]);
            AnalizerClass.expression = Convert.ToString(TestContext.DataRow["incomingData"]);

            //Actual
            string actualResult = AnalizerClass.Estimate();

            //Assert
            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "data.xml", "InValidData", DataAccessMethod.Sequential)]
        public void EstimateTest3_InValidData()
        {
            //Arrange
            string expected = Convert.ToString(TestContext.DataRow["expected"]);
            AnalizerClass.expression = Convert.ToString(TestContext.DataRow["incomingData"]);

            //Actual
            string actualResult = AnalizerClass.Estimate();

            //Assert
            Assert.AreEqual(expected, actualResult);
        }
    }
}
