using Dama.Core.Enums;
using Dama.Core.MoveValidation;
using Moq;
using NUnit.Framework;
 

namespace Dama.Tests
{
    [TestFixture]
    public class VerifyDirectionRuleTests
    {
        private Mock<IBoard> _board;
        private IsValidDirectionRule _sut;

        [SetUp]
        public void SetUp()
        {
            _board = new Mock<IBoard>();
            _sut = new IsValidDirectionRule(_board.Object);
        }
        [Test]
        public void Verify_PlayerBlackMoveAboveLeft_VerifyReturnTrue()
        {
            var origin = new Point(8, "H");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.Black
            }; 

            var result = _sut.Verify(input);

            Assert.True(result);
        }

        [Test]
        public void Verify_PlayerBlackMoveAboveRight_VerifyReturnTrue()
        {
            var origin = new Point(8, "H");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveRight(),
                Player = Player.Black
            };
            var result = _sut.Verify(input);

            Assert.True(result);
        }

        [Test]
        public void Verify_PlayerBlackMoveBelowLeft_VerifyReturnFalse()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.BelowLeft(),
                Player = Player.Black
            };

            var result = _sut.Verify(input);

            Assert.False(result);
        }

        [Test]
        public void Verify_PlayerBlackMoveBelowRight_VerifyReturnFalse()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.BelowRight(),
                Player = Player.Black
            };
             
            
            var result = _sut.Verify(input);

            Assert.False(result);
        }

        [Test]
        public void Verify_PlayerWhiteMoveBelowRight_VerifyReturnTrue()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.BelowRight(),
                Player = Player.White
            };
            
            var result = _sut.Verify(input);

            Assert.True(result);
        }

        [Test]
        public void Verify_PlayerWhiteMoveBelowLeft_VerifyReturnTrue()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.BelowLeft(),
                Player = Player.White
            };

            var result = _sut.Verify(input);

            Assert.True(result);
        }

        [Test]
        public void Verify_PlayerWhiteMoveAboveLeft_VerifyReturnFalse()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.White
            };
             
            var result = _sut.Verify(input);

            Assert.False(result);
        }

        [Test]
        public void Verify_PlayerWhiteMoveAboveRigth_VerifyReturnFalse()
        {
            var origin = new Point(7, "G");
            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveRight(),
                Player = Player.White
            };
            
            var result = _sut.Verify(input);

            Assert.False(result);
        }
    }
}