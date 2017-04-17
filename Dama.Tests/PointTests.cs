using NUnit.Framework;

namespace Dama.Tests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void CreatePoint_GettingPosition1A_Xis0Yis0()
        {
            var p = new Point(1, "A");

            Assert.AreEqual(p.X,0);
            Assert.AreEqual(p.Y, 0);
        }

        [Test]
        public void CreatePoint_GettingPosition8H_Xis70Yis7()
        {
            var p = new Point(8, "H");

            Assert.AreEqual(7,p.X );
            Assert.AreEqual( 7, p.Y);
        }

        [Test]
        [TestCase(8,"H",7,"H")]
        [TestCase(4, "C", 3, "C")]
        public void GetAbove_GettingAbovePositionOfPoint_AbovePositionReturnTheAbovePoint(int pRow,string pCol, int expRow,string expCol)
        {
            var p = new Point(pRow,pCol);
            var expected = new Point(expRow,expCol);
            var above = p.Above();

            Assert.AreEqual(above.Row, expected.Row);
            Assert.AreEqual(above.Col, expected.Col);
        }

        [Test]
        [TestCase(8, "H", 7, "G")]
        [TestCase(4, "C", 3, "B")]
        public void GetAboveLeft_GettingAboveLeftPositionOfAPoint_AboveLeftReturnTheAboveLeftPoint(int pRow, string pCol, int expRow, string expCol)
        {
            var p = new Point(pRow, pCol);
            var expected = new Point(expRow, expCol);
            var aboveL = p.AboveLeft();

            Assert.AreEqual(aboveL.Row, expected.Row);
            Assert.AreEqual(aboveL.Col, expected.Col);
        }

        [Test]
        [TestCase(8, "G", 7, "H")]
        [TestCase(4, "C", 3, "D")]
        public void GetAboveRight_GettingAboveRightPositionOfAPoint_AboveRightReturnTheAboveRightPoint(int pRow, string pCol, int expRow, string expCol)
        {
            var p = new Point(pRow, pCol);
            var expected = new Point(expRow, expCol);
            var aboveR = p.AboveRight();

            Assert.AreEqual(aboveR.Row, expected.Row);
            Assert.AreEqual(aboveR.Col, expected.Col);
        }

        [Test]
        [TestCase(7, "G", 8, "G")]
        [TestCase(1, "A", 2, "A")]
        public void GetBelow_GettingBelowPositionOfAPoint_BelowReturnTheBelowPoint(int pRow, string pCol, int expRow, string expCol)
        {
            var p = new Point(pRow, pCol);
            var expected = new Point(expRow, expCol);
            var below = p.Below();

            Assert.AreEqual(below.Row, expected.Row);
            Assert.AreEqual(below.Col, expected.Col);
        }

        [Test]
        [TestCase(7, "G", 8, "F")]
        [TestCase(1, "B", 2, "A")]
        public void GetBelowLeft_GettingBelowLeftPositionOfAPoint_BelowReturnTheBelowLeftPoint(int pRow, string pCol, int expRow, string expCol)
        {
            var p = new Point(pRow, pCol);
            var expected = new Point(expRow, expCol);
            var below = p.BelowLeft();

            Assert.AreEqual(below.Row, expected.Row);
            Assert.AreEqual(below.Col, expected.Col);
        }

        [Test]
        [TestCase(7, "G", 8, "H")]
        [TestCase(1, "A", 2, "B")]
        public void GetBelowRight_GettingBelowRightPositionOfAPoint_BelowReturnTheBelowRightPoint(int pRow, string pCol, int expRow, string expCol)
        {
            var p = new Point(pRow, pCol);
            var expected = new Point(expRow, expCol);
            var below = p.BelowRight();

            Assert.AreEqual(below.Row, expected.Row);
            Assert.AreEqual(below.Col, expected.Col);
        }


    }
}