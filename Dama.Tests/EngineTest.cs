using System.Collections.Generic;
using Moq;
using NUnit.Framework;


namespace Dama.Tests
{
    [TestFixture]
    public class EngineTest
    {
        private Mock<IBoard> _board;
        private Mock<IMoveVlidator> _validator;
        private Engine _sut;

        [SetUp]
        public void SetUp()
        {
            _board = new Mock<IBoard>();
            _validator = new Mock<IMoveVlidator>();
            _sut = new Engine(_board.Object,_validator.Object);
        }
#region NEXT_PLAYER
        [Test]
        public void NextPlayer_GameIsStarting_NextPlayerReturnBlack()
        {

            var result = _sut.NextPlayer();

            Assert.AreEqual(Player.Black, result);
        }

        [Test]
        public void NextPlayer_BlackMove_NextPlayerReturnWhite()
        {
            var origin = new Point(6, "C");
            var destination = new Point(5, "B");
            _sut.Move(origin, destination);

            var result = _sut.NextPlayer();
            Assert.AreEqual(Player.White, result);
        }

        [Test]
        public void NextPlayer_BlackMoveWhiteMove_NextPlayerReturnBlack()
        {
            var origin = new Point(6, "C");
            var destination = new Point(5, "B");

            _sut.Move(origin, destination);

            _sut.Move(origin, destination);

            var result = _sut.NextPlayer();

            Assert.AreEqual(Player.Black, result);
        }
#endregion

#region SET_DESTINATION
        [Test]
        public void Move_PlayerBlackMove_BoardSetDestinationCellBlack()
        {
            var origin = new Point(6, "C");
            var destination = new Point(5, "B");

            _sut.Move(origin, destination);
           
            _board.Verify(b => b.SetCell(CellStatus.Black, destination.X, destination.Y));
        }

        [Test]
        public void Move_PlayerBlackMoveEatingAPawn_BoardSetDestinationCellBlack()
        {
            var origin = new Point(6, "E");
            var destinations = new List<Point>
            {
                new Point(4, "C")
            };
            var destination = new Point(2, "E");
            destinations.Add(destination);

            _sut.Move(origin, destinations);
             
            _board.Verify(b => b.SetCell(CellStatus.Black, destination.X, destination.Y));
        }
#endregion

#region REMOVE_FROM_ORIGIN

        [Test]
        public void Move_PlayerBlackMove_BoardRemoveFromOrigin()
        {
            var origin = new Point(6,"E");
            var destination = new Point(5,"D");

            _sut.Move(origin,destination);
            
            _board.Verify(b=> b.Remove(origin.X,origin.Y));
        }

        [Test]
        public void Move_PlayerBlackMoveEatingAPawn_BoardRemoveFromOrigin()
        {
            var origin = new Point(6, "E");
            var destinations = new List<Point>
            {
                new Point(4, "C")
            };
            var destination = new Point(2, "E");
            destinations.Add(destination);

            _sut.Move(origin, destinations);


            _board.Verify(b => b.Remove(origin.X, origin.Y));
        }
        #endregion

#region MOVE_VALIDATION
        [Test]
        public void Move_PlayerBlackMove_EngineCallMoveValidatorBeforeSettingCellBoard()
        {
            var origin = new Point(6, "E");
            var destination = new Point(5, "D");

            _sut.Move(origin, destination);
            _validator.Verify(v => v.IsValid(Player.Black,origin, destination));
             
        }

        [Test]
        public void Move_PlayerBlackMoveEatingAPawn_EngineCallMoveValidatorBeforeSettingCellBoard()
        {
            var origin = new Point(6, "E");

            var destinations = new List<Point>
            {
                new Point(4, "C")
            };

            var destination = new Point(2, "E");

            destinations.Add(destination);

            _sut.Move(origin, destinations);

            _validator.Verify(v => v.IsValid(Player.Black, origin, destinations[0]));
            _validator.Verify(v => v.IsValid(Player.Black, destinations[0], destinations[1]));

        }
        #endregion

#region PAWN_REMOVER

        [Test]
        public void Move_PlayerBlackMoveEatingAPawn_BoardRemoveThePawnEated()
        {
            var origin = new Point(6,"E");
            var destination = new Point(4,"C");
            var eatedPawnPosition = new Point(5,"D");

            _sut.Move(origin,destination);

            _board.Verify(b=> b.Remove(eatedPawnPosition.X, eatedPawnPosition.Y));
        }

        [Test]
        public void Move_PlayerBlackMoveEatingTwoWhitePawn_BoardRemoveThePawnsEated()
        {
            var origin = new Point(7, "C");
            var destinations = new List<Point>
            {
                new Point(5, "A")
            };
            var destination = new Point(3, "C");
            destinations.Add(destination);

            var eatedPawn1Position = new Point(6, "B");
            var eatedPawn2Position = new Point(4, "B");


            _sut.Move(origin, destinations);
             
            _board.Verify(b => b.Remove(eatedPawn1Position.X, eatedPawn1Position.Y));
            _board.Verify(b => b.Remove(eatedPawn2Position.X, eatedPawn2Position.Y));
        }
#endregion


    }
}