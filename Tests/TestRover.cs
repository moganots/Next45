using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Root;

namespace Tests
{
    [TestClass]
    public class TestRover
    {
        RoverTerrain terrain;
        Rover rover;

        [TestInitialize]
        public void Test_Setup()
        {
            terrain = new RoverTerrain("88");
            rover = new Rover(terrain, "12E");
            Assert.IsNotNull(rover);
        }
        [TestMethod]
        public void Test_Init_Position_And_Direction()
        {
            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(RoverDirection.E, rover.Position.Direction);
        }
        [TestMethod]
        public void Test_Explore()
        {
            bool explore = rover.Explore("MMLMRMMRRMML");
            Assert.IsTrue(explore);
        }
        [TestMethod]
        public void Test_TurnLeft()
        {
            bool left = rover.TurnLeft();
            Assert.IsTrue(left);
        }
        [TestMethod]
        public void Test_TurnRight()
        {
            bool right = rover.TurnRight();
            Assert.IsTrue(right);
        }
        [TestMethod]
        public void Test_Move()
        {
            bool move = rover.Move();
            Assert.IsTrue(move);
        }
    }
}
