using System.Collections.Generic;


using Dama.Core.Enums;
using Dama.Core.MoveValidation;
using Dama.Core.MoveValidation.Rules;
using Moq;
using NUnit.Framework;

namespace Dama.Tests
{
    [TestFixture]
    public class MoveValidatorTests
    {
        private IMoveVlidator _sut;
        private Mock<IBoard> _board;
        private Mock<IRuleFactory<MoveInfo>> _ruleFactory;

        [SetUp]
        public void SetUp()
        {
            _board = new Mock<IBoard>();
            _ruleFactory = new Mock<IRuleFactory<MoveInfo>>();
            _sut = new MoveValidator(_board.Object,_ruleFactory.Object);
        }

        [Test]
        public void IsValid_ApplyingOneRuleAndRulePass_IsValidReturnValidationResultWithTotal1Passed1Failed0()
        {
            var mock = new Mock<IRule<MoveInfo>>();
            mock.Setup(m => m.Verify(It.IsAny<MoveInfo>())).Returns(true);
             
            _ruleFactory.Setup(m => m.GetRules(_board.Object)).Returns(new List<IRule<MoveInfo>> {mock.Object});
             

            var origin = new Point(8, "H");

            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.Black
            };

            var result = _sut.IsValid(input);

            Assert.True(result.IsValid);
            Assert.AreEqual(1, result.TotalRules);
            Assert.AreEqual(1, result.Passed);
            Assert.AreEqual(0, result.Failed);


        }

        [Test]
        public void IsValid_ApplyingTwoRulesAndRulesPass_IsValidReturnValidationResultWithTotal2Passed2Failed0()
        {
            var mock1 = new Mock<IRule<MoveInfo>>();
            mock1.Setup(m => m.Verify(It.IsAny<MoveInfo>())).Returns(true);
            var mock2 = new Mock<IRule<MoveInfo>>();
            mock2.Setup(m => m.Verify(It.IsAny<MoveInfo>())).Returns(true);

            _ruleFactory.Setup(m => m.GetRules(_board.Object)).Returns(new List<IRule<MoveInfo>> {mock1.Object,mock2.Object});


            var origin = new Point(8, "H");

            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.Black
            };

            var result = _sut.IsValid(input);

            Assert.True(result.IsValid);
            Assert.AreEqual(2, result.TotalRules);
            Assert.AreEqual(2, result.Passed);
            Assert.AreEqual(0, result.Failed);


        }

        [Test]
        public void IsValid_ApplyingTwoRulesAndRulesOnePassOneFail_IsValidReturnValidationResultWithTotal2Passed1Failed1IsValidFalse()
        {
            var mock1 = new Mock<IRule<MoveInfo>>();
            mock1.Setup(m => m.Verify(It.IsAny<MoveInfo>())).Returns(true);
            var mock2 = new Mock<IRule<MoveInfo>>();
            mock2.Setup(m => m.Verify(It.IsAny<MoveInfo>())).Returns(false);

            _ruleFactory.Setup(m => m.GetRules(_board.Object)).Returns(new List<IRule<MoveInfo>> { mock1.Object, mock2.Object });


            var origin = new Point(8, "H");

            var input = new MoveInfo
            {
                Origin = origin,
                Destination = origin.AboveLeft(),
                Player = Player.Black
            };

            var result = _sut.IsValid(input);

            Assert.False(result.IsValid);
            Assert.AreEqual(2, result.TotalRules);
            Assert.AreEqual(1, result.Passed);
            Assert.AreEqual(1, result.Failed);


        }

    }
}
