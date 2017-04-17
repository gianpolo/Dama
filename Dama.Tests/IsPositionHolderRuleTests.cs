using Dama.Core;
using Dama.Core.Enums;
using Dama.Core.MoveValidation;
using Moq;
using NUnit.Framework;

namespace Dama.Tests
{
    [TestFixture]
    public class IsPositionHolderRuleTests
    {
        private Mock<IBoard> _board;
        private IsPositionHolderRule _sut;

        [SetUp]
        public void SetUp()
        {
            _board = new Mock<IBoard>();
            _sut = new IsPositionHolderRule(_board.Object);
        }
        [Test]
        public void Verify_PlayerIsBlackCellStatusIsBlack_IsValidReturnTrue()
        {
            var origin = new Point(1, "A");

            var input = new MoveInfo
            {
                Origin = origin,
                Destination = null,
                Player = Player.Black
            };
          
            _board.Setup(b => b.GetCellStatus(origin.X, origin.Y)).Returns(CellStatus.Black);

            var result = _sut.Verify(input);

            Assert.True(result);
        }


        [Test]
        public void Verify_PlayerIsBlackCellStatusIsWhite_IsValidReturnFalse()
        {
            var origin = new Point(1, "A");

            var input = new MoveInfo
            {
                Origin = origin,
                Destination = null,
                Player = Player.Black
            };
            _board.Setup(b => b.GetCellStatus(origin.X, origin.Y)).Returns(CellStatus.White);

            var result = _sut.Verify(input);

            Assert.False(result);
        }

        [Test]
        public void Verify_PlayerIsWhiteCellStatusIsWhite_IsValidReturnTrue()
        {
            var origin = new Point(1, "A");
            

            var input = new MoveInfo
            {
                Origin = origin,
                Destination = null,
                Player = Player.White
            };
            _board.Setup(b => b.GetCellStatus(origin.X, origin.Y)).Returns(CellStatus.White);

            var result = _sut.Verify(input);
            Assert.True(result);
        }

        [Test]
        public void Verify_PlayerIsWhiteCellStatusIsBlack_IsValidReturnFalse()
        {
           
            var origin = new Point(1, "A");

            var input = new MoveInfo
            {
                Origin = origin,
                Destination = null,
                Player = Player.White
            };
            _board.Setup(b => b.GetCellStatus(origin.X, origin.Y)).Returns(CellStatus.Black);

            var result = _sut.Verify(input);
            Assert.False(result);
        }
    }
}