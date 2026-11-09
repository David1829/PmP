// 9. labor, The Console Slayer: a játék az 1-6. rész után (játékelemek, ütközés, démonok, harc)
// Minden osztály külön fájlban és a ConsoleSlayer névtérben van: a Visual Studio az Add > Class
// paranccsal így hozza létre. A főprogram enélkül a sor nélkül nem találná meg őket
// (CS0246 hiba: "The type or namespace name 'Game' could not be found").
using ConsoleSlayer;

Game game = new Game();
game.LoadMapFromPlainText("map.txt");
// Teszt-terem: 30 × 12-es terem fallal körülvéve; a 12. oszlopban egy fal, a közepén ajtóval.
// (A 10. laboron a pálya szövegfájlból töltődik be.)
for (int x = 0; x < 30; x++)
{
    game.Items.Add(new GameItem(x, 0, ItemType.Wall));
    game.Items.Add(new GameItem(x, 11, ItemType.Wall));
}
for (int y = 1; y < 11; y++)
{
    game.Items.Add(new GameItem(0, y, ItemType.Wall));
    game.Items.Add(new GameItem(29, y, ItemType.Wall));
    if (y == 5)
    {
        game.Items.Add(new GameItem(12, y, ItemType.Door));
    }
    else
    {
        game.Items.Add(new GameItem(12, y, ItemType.Wall));
    }
}
game.Items.Add(new GameItem(5, 8, ItemType.Medikit));
game.Items.Add(new GameItem(8, 2, ItemType.Ammo));
// A játékos a konstruktor szerint a (0, 0)-n kezdene, ami most fal: áttesszük a terem belsejébe.
game.Player.Position = new Position(3, 3);

// Egy-egy démon az ajtó túloldalán.
game.Demons.Add(new Demon(16, 3, DemonType.Zombieman));
game.Demons.Add(new Demon(20, 8, DemonType.Imp));
game.Demons.Add(new Demon(25, 5, DemonType.Mancubus));

Console.WriteLine("The Console Slayer");
Console.WriteLine("Nyilak: mozgás, D: ajtó és tárgyak, A: lövés, Esc: kilépés");
Console.WriteLine("Enter: indul a játék");
Console.ReadLine();

game.Run();

// A színeket visszaállítjuk, és letöröljük a pályát, mielőtt kiírunk valamit.
Console.ResetColor();
Console.Clear();
Console.CursorVisible = true;
Console.WriteLine("Vége a játéknak.");
if (!game.Player.Alive)
{
    Console.WriteLine("Doomguy elesett.");
}
Console.WriteLine($"Életerő: {game.Player.Health}, lőszer: {game.Player.Ammo}, tapasztalati pont: {game.Player.CombatPoints}");
