namespace Dama.Tests
{
    public interface IBoard
    {
        void Clean();
        CellStatus GetCellStatus(int x, int y);
        string Print();
        void Remove(int x, int y);
        void SetCell(CellStatus cellStatus, int x, int y);
    }
}