using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Root;

namespace Tests
{
    [TestClass]
    public class TestTerrain
    {
        RoverTerrain terrain;
        [TestMethod]
        public void Test_Init_Valid_Terrain()
        {
            terrain = new RoverTerrain("88");
            Assert.IsNotNull(terrain);
        }
        [TestMethod]
        public void Test_Init_InValid_Terrain()
        {
            terrain = new RoverTerrain(null);
            Assert.IsNull(terrain);
        }
    }
}
