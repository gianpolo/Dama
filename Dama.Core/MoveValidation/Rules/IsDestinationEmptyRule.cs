using Dama.Core.Enums;
using Dama.Tests;

namespace Dama.Core.MoveValidation
{
    public class IsDestinationEmptyRule : Rule<MoveInfo>
    {
        public IsDestinationEmptyRule(IBoard board) : base(board)
        {
        }

        public override bool Verify(MoveInfo args)
        {
            return Board.GetCellStatus(args.Destination.X, args.Destination.Y) == CellStatus.Free;
        }
    }
}