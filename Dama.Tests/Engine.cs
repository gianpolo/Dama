namespace Dama.Tests
{
    public class Engine     
    {
        private readonly IBoard _board;
        private Player _currentPlayer;

        public Engine(IBoard board)
        {
            _board = board;
            _currentPlayer = Player.Black;
        }

        public Player NextPlayer()
        {
            return _currentPlayer;
        }

        public void Move(int xo, int yo, int xd, int yd)
        {
            _board.Remove(5,2);
            _board.SetCell(CellStatus.Black, 4,1);
            _currentPlayer = _currentPlayer == Player.Black ? Player.White : Player.Black;
      
        }
    }
}