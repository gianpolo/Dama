using Dama.Core.MoveValidation.Rules;
using Dama.Tests;

namespace Dama.Core.MoveValidation
{
    public class MoveValidator : IMoveVlidator
    {
        private readonly IBoard _board;
        private readonly IRuleFactory<MoveInfo> _ruleFactory;

        public MoveValidator(IBoard board, IRuleFactory<MoveInfo> ruleFactory)
        {
            _board = board;
            _ruleFactory = ruleFactory;
        }

        public MoveValidationResult IsValid(MoveInfo input)
        {
            var rules = _ruleFactory.GetRules(_board);
            var result = new MoveValidationResult
            {
                TotalRules = 0,
                Passed = 0,
                Failed = 0,
                IsValid = true
            };

            foreach (var r in rules)
            {
                result.TotalRules++;
                var passed = r.Verify(input);
                if (passed)
                    result.Passed++;
                else
                {
                    result.Failed++;
                    result.IsValid = false;
                }
            }
            return result;

        } 
    }
}