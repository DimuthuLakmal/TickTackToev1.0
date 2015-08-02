using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TickTackToev1_0;

namespace TicTacToeTest
{
    /// <summary>
    /// Test for check getScore method which tests designs of winnings
    /// </summary>
    [TestClass]
    public class TestGetScore
    {
        [TestMethod]
        public void TestTypeX1()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { "x", "x", "x", " ", " ", " ", " ", " ", " " });
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void TestTypeX2()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", " ", " ", "x", "x", "x", " ", " ", " " });
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void TestTypeX3()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", " ", " ", " ", " ", " ", "x", "x", "x" });
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void TestTypeX4()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { "x", " ", " ", "x", " ", " ", "x", " ", " " });
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void TestTypeX5()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", "x", " ", " ", "x", " ", " ", "x", " " });
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void TestTypeX6()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", " ", "x", " ", " ", "x", " ", " ", "x" });
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void TestTypeX7()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { "x", " ", " ", " ", "x", " ", " ", " ", "x" });
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void TestTypeX8()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", " ", "x", " ", "x", " ", "x", " ", " " });
            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void TestTypeO1()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { "o", "o", "o", " ", " ", " ", " ", " ", " " });
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void TestTypeO2()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", " ", " ", "o", "o", "o", " ", " ", " " });
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void TestTypeO3()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", " ", " ", " ", " ", " ", "o", "o", "o" });
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void TestTypeO4()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { "o", " ", " ", "o", " ", " ", "o", " ", " " });
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void TestTypeO5()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", "o", " ", " ", "o", " ", " ", "o", " " });
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void TestTypeO6()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", " ", "o", " ", " ", "o", " ", " ", "o" });
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void TestTypeO7()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { "o", " ", " ", " ", "o", " ", " ", " ", "o" });
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void TestTypeO8()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { " ", " ", "o", " ", "o", " ", "o", " ", " " });
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void TestTypeD1()
        {
            var testclass = new TickTackToe();
            var output = testclass.getScore(new String[] { "x", "o", "o", "o", "x", "x", "o", "x", "o" });
            Assert.AreEqual(0, output);
        }
    }
}
