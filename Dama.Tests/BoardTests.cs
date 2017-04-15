using NUnit.Framework;

namespace Dama.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void CleanBoard_AfterBoardCreation_ReturnAnEmptyBoardWithFreeAndUnavailableCells()
        {
            var board = new Board();


            board.Clean();
            var result = board.GetCellStatus(0, 1);


            Assert.AreEqual(Cell.Free, result);
        }

        [Test]
        public void GetCellStatus_CellStatusIsBlack_GetStatusReturnBlack()
        {
            var board = new Board();

            var result = board.GetCellStatus(5, 0);

            Assert.AreEqual(Cell.Black, result);
        }

        [Test]
        public void GetCellStatus_CellStatusIsFree_GetStatusReturnFree()
        {
            var board = new Board();
            board.SetCell(Cell.Free, 0, 0);
            var result = board.GetCellStatus(0, 0);

            Assert.AreEqual(Cell.Free, result);
        }

        [Test]
        public void GetCellStatus_CellStatusIsWhite_GetStatusReturnWhite()
        {
            var board = new Board();

            var result = board.GetCellStatus(0, 1);

            Assert.AreEqual(Cell.White, result);
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
            var board = new Board();
            board.Clean();

            var result = board.Print();
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
            var board = new Board();
            var result = board.Print();

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
            var board = new Board();
            board.Remove(0, 1);

            var result = board.Print();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Remove_CellStatusIsBlack_GetStatusReturnFree()
        {
            var board = new Board();
            board.Remove(5, 0);

            var result = board.GetCellStatus(5, 0);

            Assert.AreEqual(Cell.Free, result);
        }

        [Test]
        public void SetCell_SetCellBlack_GetStatusReturnBlack()
        {
            var board = new Board();
            board.SetCell(Cell.Black, 0, 0);
            var result = board.GetCellStatus(0, 0);

            Assert.AreEqual(Cell.Black, result);
        }

        [Test]
        public void SetCell_SetCellFree_GetStatusReturnFree()
        {
            var board = new Board();
            board.SetCell(Cell.Free, 0, 0);
            var result = board.GetCellStatus(0, 0);

            Assert.AreEqual(Cell.Free, result);
        }

        [Test]
        public void SetCell_SetCellWhite_GetStatusReturnWhite()
        {
            var board = new Board();
            board.SetCell(Cell.White, 0, 0);
            var result = board.GetCellStatus(0, 0);

            Assert.AreEqual(Cell.White, result);
        }
    }

    public class Board
    {
        public static int BOARD_SIZE = 8;
        private Cell[,] _board;

        public Board()
        {
            _board = new Cell[BOARD_SIZE, BOARD_SIZE];
            InitBoard();
        }

        private void InitBoard()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    _board[i, j] = DefaultCell(i, j);
                }
            }
        }

        private Cell DefaultCell(int x, int y)
        {
            if ((x + y) % 2 == 0)
            {
                return Cell.Unavailable;
            }

            if (x == 3 || x == 4)
            {
                return Cell.Free;
            }
            if (x > 3)
            {
                return Cell.Black;
            }
            return Cell.White;
        }

        public void Clean()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (_board[i, j] != Cell.Unavailable)
                        _board[i, j] = Cell.Free;
                }
            }
        }

        public Cell GetCellStatus(int x, int y)
        {
            return _board[x, y];
        }

        public void SetCell(Cell cell, int x, int y)
        {
            _board[x, y] = cell;
        }

        public string Print()
        {
            string boardString = "";
            var line = 1;
            foreach (var cell in _board)
            {

                var s = PrintCell(cell);

                boardString += s;
                line++;

                if (line % 9 == 0)
                {
                    boardString += System.Environment.NewLine;
                    line = 1;
                }
                else
                {
                    boardString += " ";
                }

            }
            return boardString;
        }

        private static string PrintCell(Cell cell)
        {
            string s = "";
            if (cell == Cell.Free)
            {
                s = "-";
            }
            if (cell == Cell.Unavailable)
            {
                s = " ";
            }
            if (cell == Cell.Black)
            {
                s = "b";
            }
            if (cell == Cell.White)
            {
                s = "w";
            }
            return s;
        }

        public void Remove(int x, int y)
        {
            _board[x, y] = Cell.Free;
        }
    }

    public enum Cell
    {
        Unavailable = 0,
        Free,
        White,
        Black
    }
}