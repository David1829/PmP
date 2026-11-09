// 9. labor, The Console Slayer: mit csinál épp egy démon
namespace ConsoleSlayer
{
    internal enum DemonStateType
    {
        Idle,       // áll, nem látja a játékost
        Move,       // látja a játékost, mozog
        Attack      // támadótávon belül van, támad
    }
}
