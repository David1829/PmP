
namespace ConsoleSlayer
{
    internal class ConsoleRenderer
    {
        private Game game;

        public ConsoleRenderer(Game game)
        {
            this.game = game;
        }

        // Egyetlen sprite kirajzolása.
        private void RenderSingleSprite(Position position, ConsoleSprite sprite)
        {
            if (position.X >= 0 &&
                position.X < Console.WindowWidth &&
                position.Y >= 0 &&
                position.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.BackgroundColor = sprite.Background;
                Console.ForegroundColor = sprite.Foreground;
                Console.Write(sprite.Glyph);
            }
        }

        // A játékos adatainak megjelenítése a képernyő alsó sorában.
        private void RenderHUD()
        {
            Player player = game.Player;

            string hud = $" Health: {player.Health}/{player.MaxHealth} | " +
                         $"Ammo: {player.Ammo}/{player.MaxAmmo} | " +
                         $"BFG Cells: {player.BFGCells}/{player.MaxBFGCells} | " +
                         $"XP: {player.CombatPoints} ";

            Console.SetCursorPosition(0, Console.WindowHeight - 1);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            // A sor teljes kitöltése egységes háttérszínnel.
            Console.Write(hud.PadRight(Console.WindowWidth));

            Console.ResetColor();
        }

        // A teljes játék kirajzolása.

        public void RenderGame()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.Clear();

            // Csak a látótávolságon belüli játékelemek kirajzolása.
            foreach (GameItem item in game.Items)
            {
                double distance = Position.Distance(
                    game.Player.Position,
                    item.Position);

                if (distance <= game.Player.SightRange)
                {
                    RenderSingleSprite(item.Position, item.Sprite);
                }
            }

            // Csak a látótávolságon belüli démonok kirajzolása.
            foreach (Demon demon in game.Demons)
            {
                double distance = Position.Distance(
                    game.Player.Position,
                    demon.Position);

                if (distance <= game.Player.SightRange)
                {
                    RenderSingleSprite(demon.Position, demon.Sprite);
                }
            }

            // Játékos kirajzolása.
            RenderSingleSprite(game.Player.Position, game.Player.Sprite);

            // HUD kirajzolása.
            RenderHUD();
        }

    }
}
