using Dama.Core.Enums;
using Dama.Tests;

namespace Dama.Core.MoveValidation
{
    public class MoveInfo
    {
        public Player Player { get; set; }
        public Point Origin { get; set; }
        public Point Destination { get; set; }
    }
}