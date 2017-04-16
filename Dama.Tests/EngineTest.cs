using Moq;
using NUnit.Framework;


namespace Dama.Tests
{
    [TestFixture]
    public class EngineTest
    {
        private Mock<IBoard> _board;
        private Engine _sut;

        [SetUp]
        public void SetUp()
        {
            _board = new Mock<IBoard>();
            _sut = new Engine(_board.Object);
        }

        [Test]
        public void NextPlayer_GameIsStarting_NextPlayerReturnBlack()
        {
         
            var result = _sut.NextPlayer();

            Assert.AreEqual(Player.Black,result);
        }
         

        [Test]
        public void  NextPlayer_BlackMove_NextPlayerIsWhite()
        {

            _sut.Move(5, 2, 4, 1);

            var result = _sut.NextPlayer();
            Assert.AreEqual(Player.White,result);
        }

        [Test]
        public void NextPlayer_BlackMoveWhiteMove_NextPlayerIsBlack()
        {

            _sut.Move(5, 2, 4, 1);
            _sut.Move(5, 2, 4, 1);
            var result = _sut.NextPlayer();

            Assert.AreEqual(Player.Black, result);
        }

        [Test]
        public void Move_PlayerBlackMoveUpLeftAPawn_BoardRemoveFromOriginAndSetToDestination()
        {

            _sut.Move(5, 2, 4, 1);

            _board.Verify(b => b.Remove(5, 2));
            _board.Verify(b => b.SetCell(CellStatus.Black, 4, 1));
        }

        
    }
}