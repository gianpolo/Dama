using System.Collections.Generic;
using Dama.Tests;

namespace Dama.Core.MoveValidation.Rules
{
    public interface IRuleFactory<T>
    {
        List<IRule<T>> GetRules(IBoard board);
    }

    public class RuleFactory : IRuleFactory<MoveInfo>
    {
        public List<IRule<MoveInfo>> GetRules(IBoard board)
        {
            var list = new List<IRule<MoveInfo>>
            {
                new IsPositionHolderRule(board),
                new IsDestinationEmptyRule(board),
                new IsValidDirectionRule(board)
            };
            return list;
        }
    }
}