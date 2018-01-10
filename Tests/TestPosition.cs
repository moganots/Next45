using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Root;

namespace Tests
{
    [TestClass]
    public class TestPosition
    {
        RoverTerrain terrain;
        RoverPosition position;
        [TestInitialize]
        public void Test_Setup()
        {
            terrain = new RoverTerrain("88");
            Assert.IsNotNull(terrain);
        }
        [TestMethod]
        public void Test_Init_Valid_Position()
        {
            position = new RoverPosition(terrain, "12E");
            Assert.IsNotNull(position);
        }
        [TestMethod]
        public void Test_Init_InValid_Position_NoDirection()
        {
            position = new RoverPosition(terrain, "12");
            Assert.IsNull(position);
        }
    }
}
