using System;
using Kata_Bowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestKataBowling
{
    [TestClass]
    public class UnitTest1
    {
        private Game g;

        [TestInitialize]
        public void InitialiazeGame()
        {
            g = new Game();;
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            g.Roll(pins);
        }

        private void RollSpare()
        {
            g.Roll(7);
            g.Roll(3);
        }

        [TestMethod]
        public void TestNullGame()
        {
            RollMany(20,0);
            Assert.AreEqual(0,g.Score());
        }

        [TestMethod]
        public void TestExellentGame()
        {
            RollMany(12,10);
            Assert.AreEqual(300,g.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(6);
            RollMany(17,0);
            Assert.AreEqual(22,g.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(5);
            g.Roll(3);
            RollMany(16,0);
            Assert.AreEqual(26,g.Score());
        }

        [TestMethod]
        public void TestAllThree()
        {
            RollMany(20,3);
            Assert.AreEqual(60,g.Score());
        }

        [TestMethod]
        public void TestAllSpare()
        {
            RollMany(21,5);
            Assert.AreEqual(150,g.Score());
        }
    }
}
