using DOOM.enums;

namespace DOOM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game doomGame = new Game();
            doomGame.Items.Add(new GameItem(5, 4, ItemType.Door));     // Egy ajtó (kezdetben '/' jel)
            doomGame.Items.Add(new GameItem(12, 6, ItemType.Medikit)); // Elsősegély csomag ('+')
            doomGame.Items.Add(new GameItem(20, 3, ItemType.Ammo));    // Lőszer csomag ('A')
            doomGame.Items.Add(new GameItem(8, 8, ItemType.Wall));
            doomGame.Run();
        }
    }
}
