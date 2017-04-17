namespace Dama.Tests
{
    public class Point
    {
        public int Row { get; private set; }
        public string Col { get; private set; }

        public int X { get; private set; }
        public int Y { get; set; }

        public Point(int row,string col)
        {
            Row = row;
            Col = col;

            X = row -1; 
            Y = GetColNumber(col);
        }

        private int GetColNumber(string col)
        {
            // A = 97 , H = 72
            var ascii =(int) (col.ToUpper()[0]);
            return ascii - 65;
        }

      
        public Point Above()
        {
            return new Point(RowUp(this.Row),this.Col);         
        }

        public Point AboveLeft()
        {
             
            return new Point(RowUp(this.Row),Left(this.Col));
        }

        public Point AboveRight()
        {
            return new Point(RowUp(this.Row), Right(this.Col));
        }

        public Point Below()
        {
            return new Point(RowDown(this.Row), this.Col);
        }

        private string Left(string col)
        {
            int newColAscii = col[0] - 1;
            char newColChar = (char)newColAscii;
            return newColChar.ToString();
        }

        private string Right(string col)
        {
            int newColAscii = col[0] + 1;
            char newColChar = (char)newColAscii;
            return newColChar.ToString();
        }

        private int RowUp(int row)
        {
            return row - 1;
        }

        private int RowDown(int row)
        {
            return row + 1;
        }

        public Point BelowLeft()
        {
            return new Point(RowDown(this.Row),Left(this.Col));
        }

        public Point BelowRight()
        {
            return new Point(RowDown(this.Row), Right(this.Col));
        }
    }
}