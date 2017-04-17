using System.Collections.Generic;
using Dama.Core.Enums;
using Dama.Core.MoveValidation;
using Dama.Tests;

namespace Dama.Core
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
            var validation = new MoveInfo
            {
                Origin = origin,
                Destination = destination,
                Player = _currentPlayer
            };

            _validator.IsValid(validation);
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
                var validation = new MoveInfo
                {
                    Origin = tmp,
                    Destination = dest,
                    Player = _currentPlayer
                };
                _validator.IsValid(validation);
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

     
     
}