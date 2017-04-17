using Dama.Core;
using Dama.Core.Enums;
using Dama.Core.MoveValidation;
using Dama.Tests;

namespace Dama.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var val = new MoveValidator(board);
            var engine = new Engine(board,val);

            System.Console.WriteLine("Hello from Dama");

            var b = board.PrintWithGuides();
            System.Console.WriteLine(b);
            var p = engine.NextPlayer();
            if (p == Player.Black)
                System.Console.WriteLine("Black move: ");
            else
                System.Console.WriteLine("White move: ");

            var str = System.Console.ReadLine();
            var commands = str.Split(',');
            var originRow = 0;
            int.TryParse(commands[0], out originRow);
            
            var originCol = commands[1];
            System.Console.WriteLine("Destination: ");

            str = System.Console.ReadLine();
             commands = str.Split(',');
            var destinationRow = 0;
            int.TryParse(commands[0], out destinationRow);
            var destinationCol = commands[1];

            System.Console.WriteLine("Black want move:{0},{1} --> {2},{3}",originRow,originRow,destinationRow,destinationCol);
            var point= new Point(originRow,originCol);
            var p2 = new Point(destinationRow,destinationCol);
            engine.Move(point,p2);

            b = board.PrintWithGuides();
            System.Console.WriteLine(b);
            str = System.Console.ReadLine();
        }
    }
}
