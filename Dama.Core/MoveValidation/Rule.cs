using Dama.Tests;

namespace Dama.Core.MoveValidation
{
    public abstract class Rule<MoveInfo> : IRule<MoveInfo>
    {
        protected readonly IBoard Board;

        protected Rule(IBoard board)
        {
            Board = board;
        }


        public abstract bool Verify(MoveInfo input);
         
    }

    public interface IRule<T>
    {
        bool Verify(T input);
    }
}