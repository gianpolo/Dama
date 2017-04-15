namespace Dama.Tests
{
    public class Board
    {
        public static int BOARD_SIZE = 8;
        private readonly Cell[,] _board;

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
}