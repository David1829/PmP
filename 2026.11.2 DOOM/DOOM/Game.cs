using System.Numerics;

namespace DOOM
{
    internal class Game
    {
        public Player Player { get; }
        public bool Exited { get; set; }
        public List<GameItem> Items { get; private set; }



        public Game()
        {
            Player = new Player(0, 0);
            Exited = false;
            Items = new List<GameItem>();

        }
        private List<GameItem> GetGameItemsWithinDistance(Position pos, double maxDistance)
        {
            List<GameItem> result = new List<GameItem>();
            foreach (var item in Items)
            {
               
                if (maxDistance == 0)
                {
                    if (item.Position.X == pos.X && item.Position.Y == pos.Y)
                    {
                        result.Add(item);
                    }
                }
             
                else if (Position.Distance(pos, item.Position) <= maxDistance)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private double GetTotalFillingRatio(Position pos)
        {
           
            List<GameItem> itemsAtPos = GetGameItemsWithinDistance(pos, 0);
            double totalRatio = 0;
            foreach (var item in itemsAtPos)
            {
                totalRatio += item.FillingRatio;
            }
            return totalRatio;
        }

        private void Move(Player player, Position targetPos)
        {
            double itemsFillingRatio = GetTotalFillingRatio(targetPos);

            double playerFillingRatio = 0.0;

            if (itemsFillingRatio + playerFillingRatio <= 1.0)
            {
                player.Position = targetPos;
            }
        }
        private void RenderSingleSprite(Position position, ConsoleSprite sprite)
        {
            if (position.X >= 0 && position.X < Console.WindowWidth && position.Y >= 0 && position.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.BackgroundColor = sprite.Background;
                Console.ForegroundColor = sprite.Foreground;
                Console.Write(sprite.Glyph);
            }
        }
        private void RenderGame()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.Clear();
            RenderSingleSprite(Player.Position, Player.Sprite);

            foreach (var item in Items)
            {
                RenderSingleSprite(item.Position, item.Sprite);
                RenderSingleSprite(Player.Position, Player.Sprite);
            }
            
        }
        private void UserAction()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                Position direction = null;
                switch (pressed.Key)
                {
                    case ConsoleKey.Escape:
                        Exited = true;
                        break;
                    case ConsoleKey.UpArrow:
                        Move(Player, Position.Add(Player.Position,
new Position(0, -1)));
                        break;
                    case ConsoleKey.DownArrow:
                        Move(Player, Position.Add(Player.Position,
                        new Position(0, 1)));
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(Player, Position.Add(Player.Position,
                        new Position(-1, 0)));
                        break;
                    case ConsoleKey.RightArrow:
                        Move(Player, Position.Add(Player.Position,
                        new Position(1, 0)));
                        break;
                    case ConsoleKey.D:
                        foreach (var item in Items)
                        {
                            item.Interact();
                        }
                        break;
                }
                if (direction != null)
                {
                    Position targetPosition = Position.Add(Player.Position, direction);
                    Move(Player, targetPosition);
                }
            }
        }
        private void CleanUpGameItems()
        {
            List<GameItem> toRemove = new List<GameItem>();
            foreach (var item in Items)
            {
                if (!item.Available)
                {
                    toRemove.Add(item);
                }
            }
            foreach (var item in toRemove)
            {
                Items.Remove(item);
            }
        }
        public void Run()
        {
            while (!Exited)
            {
                RenderGame();
                UserAction();
                CleanUpGameItems();
                Thread.Sleep(25);
            }
        }
    }
}
