using System.Net.NetworkInformation;
using Dama.Core.Enums;
using Dama.Core.MoveValidation;
using Moq;
using NUnit.Framework;
 

namespace Dama.Tests
{
    [TestFixture]
    public class IsDestinationEmptyRuleTests
    {
        private Mock<IBoard> _board;
        private IsDestinationEmptyRule _sut;

        [SetUp]
        public void SetUp()
        {
            _board = new Mock<IBoard>();
            _sut = new IsDestinationEmptyRule(_board.Object);
        }
        [Test]
        public void IsValid_PlayerBlackMoveToFreeCellStatus_IsValidReturnTrue()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.Black
            };
            
             
            _board.Setup(b => b.GetCellStatus(input.Destination.X, input.Destination.Y)).Returns(CellStatus.Free);
            
            var result = _sut.Verify(input);
            Assert.True(result);
        }
        [Test]
        public void IsValid_PlayerWhiteMoveToDestinationCellStatusFree_IsValidReturnTrue()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.White
            };


            _board.Setup(b => b.GetCellStatus(input.Destination.X, input.Destination.Y)).Returns(CellStatus.Black);

            var result = _sut.Verify(input);
            Assert.False(result);
        }
        [Test]
        public void IsValid_PlayerBlackMoveToDestinationCellStatusBlack_IsValidReturnFalse()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.Black
            };

           
            _board.Setup(b => b.GetCellStatus(input.Destination.X, input.Destination.Y)).Returns(CellStatus.Black);

            var result = _sut.Verify(input);
            Assert.False(result);
        }

        [Test]
        public void IsValid_PlayerBlackMoveToDestinationCellStatusWhite_IsValidReturnFalse()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.Black
            };

          
            _board.Setup(b => b.GetCellStatus(input.Destination.X, input.Destination.Y)).Returns(CellStatus.White);

            var result = _sut.Verify(input);
            Assert.False(result);
        }

        [Test]
        public void IsValid_PlayerWhiteMoveToDestinationCellStatusWhite_IsValidReturnFalse()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.White
            };


            _board.Setup(b => b.GetCellStatus(input.Destination.X, input.Destination.Y)).Returns(CellStatus.White);

            var result = _sut.Verify(input);
            Assert.False(result);
        }

        [Test]
        public void IsValid_PlayerWhiteMoveToDestinationCellStatusBlack_IsValidReturnFalse()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.White
            };


            _board.Setup(b => b.GetCellStatus(input.Destination.X, input.Destination.Y)).Returns(CellStatus.Black);

            var result = _sut.Verify(input);
            Assert.False(result);
        }

       
    }
}