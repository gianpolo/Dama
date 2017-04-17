using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;


namespace Dama.Tests
{
    public class Engine     
    {
        private readonly IBoard _board;
        private readonly IMoveVlidator _validator;
        private Player _currentPlayer;

        public Engine(IBoard board, IMoveVlidator validator)
        {
            _board = board;
            _validator = validator;
            _currentPlayer = Player.Black;
        }

        public Player NextPlayer()
        {
            return _currentPlayer;
        }

        public void Move(Point origin, Point destination)
        {
            _validator.IsValid(_currentPlayer, origin, destination);
             var toRemove = GetPositionToRemove(origin,destination);
            _board.Remove(toRemove.X,toRemove.Y);

            MovePlayerPawn(origin, destination);

            SetNextPlayer();
      
        }

        private Point GetPositionToRemove(Point origin,Point destination)
        {
            if (origin.Y > destination.Y)
                return origin.AboveLeft();
           
            return origin.AboveRight();

           
        }

        private void MovePlayerPawn(Point origin,Point destination)
        {
            var xo = origin.X;
            var yo = origin.Y;
            var xd = destination.X;
            var yd = destination.Y;

            _board.Remove(xo, yo);
             
            _board.SetCell(CellStatus.Black, xd, yd);
        }

        public void Move(Point origin, List<Point> destinations)
        {
            var tmp = origin;

            foreach (var dest in destinations)
            {
                _validator.IsValid(_currentPlayer,tmp,dest);
                tmp = dest;
            }

            tmp = origin;
            foreach (var destination in destinations)
            {
                Move(tmp, destination);
                tmp = destination;
            }
        }

       

        private void SetNextPlayer()
        {
            _currentPlayer = _currentPlayer == Player.Black ? Player.White : Player.Black;
        }
    }

    public class PawnRemover
    {
        private readonly IBoard _board;

        public PawnRemover(IBoard board)
        {
            _board = board;
           
        }

        public void Remove(int i, int i1, int xo, int yo)
        {
            _board.Remove(4, 3);
            _board.Remove(xo, yo);
        }
    }

    public class MoveValidator
    {
        private readonly IBoard _board;

        public MoveValidator(IBoard board)
        {
            _board = board; 
        }

        public void IsValid(Player currentPlayer, int xo, int yo, int xd, int yd)
        {
            _board.GetCellStatus(xo, yo);
            _board.GetCellStatus(xd, yd);
            _board.GetCellStatus(4, 3);
        }
    }
}