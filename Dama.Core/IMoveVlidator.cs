namespace Dama.Tests
{
    public interface IMoveVlidator
    {
        void IsValid(Player player, Point origin, Point destination);
    }
}