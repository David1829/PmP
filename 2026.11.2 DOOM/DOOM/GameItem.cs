using DOOM.enums;

namespace DOOM
{
    internal class GameItem
    {
        public Position Position { get; }
        public ConsoleSprite Sprite { get; private set; }

        public ItemType Type { get; }

        public double FillingRatio { get; private set; }
        public bool Available { get; private set; }
        public GameItem (int x, int y, ItemType type)
        {
            Position = new Position (x, y);
            Type = type;
            Available = true;

            SetInitialProperties();
        }

        private void SetInitialProperties()
        {
            switch (Type)
            {
                case ItemType.Ammo:
                    FillingRatio = 0.0;
                    Sprite = new ConsoleSprite(ConsoleColor.Red, ConsoleColor.Yellow, 'A');
                    break;
                case ItemType.BFGCell:
                    FillingRatio = 0.0;
                    Sprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.White, 'B');
                    break;
                case ItemType.Door:
                    FillingRatio = 1.0;
                    Sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Red, '/');
                    break;
                case ItemType.LevelExit:
                    FillingRatio = 1.0;
                    Sprite = new ConsoleSprite(ConsoleColor.Blue, ConsoleColor.Black, 'E');
                    break;
                case ItemType.Medikit:
                    FillingRatio = 0.0;
                    Sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Red, '+');
                    break;
                case ItemType.ToxicWaste:
                    FillingRatio = 0.0;
                    Sprite = new ConsoleSprite(ConsoleColor.DarkGreen, ConsoleColor.Green, ':');
                    break;
                case ItemType.Wall:
                    FillingRatio = 1.0;
                    Sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Gray, '#');
                    break;
            }
        }
        public void Interact()
        {
            switch (Type)
            {
                case ItemType.Ammo:
                case ItemType.BFGCell:
                case ItemType.Medikit:
                    Available = false;
                    break;
                case ItemType.Door:
                    FillingRatio = 0.0;
                    Sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.White, '/');
                    break;
            }
        }
    }
}
