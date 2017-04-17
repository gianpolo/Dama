using Dama.Core.Enums;
using Dama.Tests;

namespace Dama.Core.MoveValidation
{
    public class IsValidDirectionRule : Rule<MoveInfo>
    {
        public IsValidDirectionRule(IBoard board) : base(board)
        {
        }

        public override bool Verify(MoveInfo args)
        {
            var direction = GetDirection(args.Origin, args.Destination);
            return IsValidDirection(args.Player, direction);
        }

        private bool IsValidDirection(Player player, Direction direction)
        {
            if (player == Player.Black)
                return direction == Direction.AboveLeft || direction == Direction.AboveRight;

            return direction == Direction.BelowLeft || direction == Direction.BelowRight;
        }

        private Direction GetDirection(Point origin, Point destination)
        {
            if (origin.X > destination.X)
            {
                return origin.Y > destination.Y ? Direction.AboveLeft : Direction.AboveRight;
            }

            return origin.Y > destination.Y ? Direction.BelowLeft : Direction.BelowRight;
        }
    }
}