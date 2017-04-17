using Dama.Core.Enums;
using Dama.Tests;

namespace Dama.Core.MoveValidation
{
    public class IsPositionHolderRule : Rule<MoveInfo>
    {
        public IsPositionHolderRule(IBoard board) : base(board)
        {
        }
        public override bool Verify(MoveInfo args)
        {
            var cellStatus = Board.GetCellStatus(args.Origin.X, args.Origin.Y);
            return (args.Player == Player.Black && cellStatus == CellStatus.Black) || (args.Player == Player.White && cellStatus == CellStatus.White);
        }
    }
}