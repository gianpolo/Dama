using Dama.Core.Enums;
using NUnit.Framework;

namespace Dama.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private Board _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Board(); 

        }
        [Test]
        public void CleanBoard_AfterBoardCreation_ReturnAnEmptyBoardWithFreeAndUnavailableCells()
        {


            _sut.Clean();
            var result = _sut.GetCellStatus(0, 1);


            Assert.AreEqual(CellStatus.Free, result);
        }

        [Test]
        public void GetCellStatus_CellStatusIsBlack_GetStatusReturnBlack()
        {
          

            var result = _sut.GetCellStatus(5, 0);

            Assert.AreEqual(CellStatus.Black, result);
        }

        [Test]
        public void GetCellStatus_CellStatusIsFree_GetStatusReturnFree()
        {
            _sut.SetCell(CellStatus.Free, 0, 0);

            var result = _sut.GetCellStatus(0, 0);

            Assert.AreEqual(CellStatus.Free, result);
        }

        [Test]
        public void GetCellStatus_CellStatusIsWhite_GetStatusReturnWhite()
        {
            var result = _sut.GetCellStatus(0, 1);

            Assert.AreEqual(CellStatus.White, result);
        }

        [Test]
        public void PrintBoard_BoardIsEmpty_PrintReturnAStringRapresentingTheBoard()
        {
            var expected = @"  -   -   -   -
-   -   -   -  
  -   -   -   -
-   -   -   -  
  -   -   -   -
-   -   -   -  
  -   -   -   -
-   -   -   -  
";

            _sut.Clean();

            var result = _sut.Print();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintBoard_DefaultCellStatus_PrintReturnAStringRapresentingTheBoard()
        {
            
            var expected = @"  w   w   w   w
w   w   w   w  
  w   w   w   w
-   -   -   -  
  -   -   -   -
b   b   b   b  
  b   b   b   b
b   b   b   b  
";
           

            var result = _sut.Print();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintBoard_OneCellSettedFree_PrintReturnAStringRapresentingTheBoard()
        {
            
            var expected = @"  -   w   w   w
w   w   w   w  
  w   w   w   w
-   -   -   -  
  -   -   -   -
b   b   b   b  
  b   b   b   b
b   b   b   b  
";

            _sut.Remove(0, 1);

            var result = _sut.Print();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Remove_CellStatusIsBlack_GetStatusReturnFree()
        {

            _sut.Remove(5, 0);

            var result = _sut.GetCellStatus(5, 0);

            Assert.AreEqual(CellStatus.Free, result);
        }

        [Test]
        public void SetCell_SetCellBlack_GetStatusReturnBlack()
        {

            _sut.SetCell(CellStatus.Black, 0, 0);

            var result = _sut.GetCellStatus(0, 0);

            Assert.AreEqual(CellStatus.Black, result);
        }

        [Test]
        public void SetCell_SetCellFree_GetStatusReturnFree()
        {

            _sut.SetCell(CellStatus.Free, 0, 0);

            var result = _sut.GetCellStatus(0, 0);

            Assert.AreEqual(CellStatus.Free, result);
        }

        [Test]
        public void SetCell_SetCellWhite_GetStatusReturnWhite()
        {

            _sut.SetCell(CellStatus.White, 0, 0);

            var result = _sut.GetCellStatus(0, 0);

            Assert.AreEqual(CellStatus.White, result);
        }

        [Test]
        public void PrintWithGuides_PrintAFormattedBoard()
        {
            var expected = @"  A B C D E F G H
1   w   w   w   w
2 w   w   w   w  
3   w   w   w   w
4 -   -   -   -  
5   -   -   -   -
6 b   b   b   b  
7   b   b   b   b
8 b   b   b   b  
";

            var result = _sut.PrintWithGuides();
            Assert.AreEqual(expected,result);
        }
    }
}