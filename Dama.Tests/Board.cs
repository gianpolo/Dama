namespace Dama.Tests
{
    public class Board : IBoard
    {
        public static int BOARD_SIZE = 8;
        private readonly CellStatus[,] _board;

        public Board()
        {
            _board = new CellStatus[BOARD_SIZE, BOARD_SIZE];
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

        private CellStatus DefaultCell(int x, int y)
        {
            if ((x + y) % 2 == 0)
            {
                return CellStatus.Unavailable;
            }

            if (x == 3 || x == 4)
            {
                return CellStatus.Free;
            }
            if (x > 3)
            {
                return CellStatus.Black;
            }
            return CellStatus.White;
        }

        public void Clean()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (_board[i, j] != CellStatus.Unavailable)
                        _board[i, j] = CellStatus.Free;
                }
            }
        }

        public CellStatus GetCellStatus(int x, int y)
        {
            return _board[x, y];
        }

        public void SetCell(CellStatus cellStatus, int x, int y)
        {
            _board[x, y] = cellStatus;
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

        private static string PrintCell(CellStatus cellStatus)
        {
            string s = "";
            if (cellStatus == CellStatus.Free)
            {
                s = "-";
            }
            if (cellStatus == CellStatus.Unavailable)
            {
                s = " ";
            }
            if (cellStatus == CellStatus.Black)
            {
                s = "b";
            }
            if (cellStatus == CellStatus.White)
            {
                s = "w";
            }
            return s;
        }

        public void Remove(int x, int y)
        {
            _board[x, y] = CellStatus.Free;
        }
    }
}