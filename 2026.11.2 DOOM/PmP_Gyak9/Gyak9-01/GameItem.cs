// 9. labor, The Console Slayer: egy játékelem (fal, ajtó, lőszer, ...)
namespace ConsoleSlayer
{
    internal class GameItem
    {
        private Position position;
        private ConsoleSprite sprite;
        private ItemType type;
        private double fillingRatio;    // a csempe mekkora részét tölti ki: 1.0-s elemre nem lehet rálépni
        private bool available;         // hamis, ha felvették: ilyenkor el kell tüntetni a pályáról

        public GameItem(int x, int y, ItemType type)
        {
            position = new Position(x, y);
            this.type = type;
            available = true;
            SetInitialProperties();
        }

        public Position Position
        {
            get { return position; }
        }

        public ConsoleSprite Sprite
        {
            get { return sprite; }
        }

        public ItemType Type
        {
            get { return type; }
        }

        public double FillingRatio
        {
            get { return fillingRatio; }
        }

        public bool Available
        {
            get { return available; }
        }

        // A típustól függő kitöltési tényező és kinézet a jegyzet 1. táblázata alapján.
        private void SetInitialProperties()
        {
            switch (type)
            {
                case ItemType.Ammo:
                    fillingRatio = 0.0;
                    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Yellow, 'A');
                    break;
                case ItemType.BFGCell:
                    fillingRatio = 0.0;
                    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'B');
                    break;
                case ItemType.Door:
                    // Kezdetben zárva: nem lehet átmenni rajta, amíg ki nem nyitjuk (D billentyű).
                    fillingRatio = 1.0;
                    sprite = new ConsoleSprite(ConsoleColor.DarkYellow, ConsoleColor.Black, '/');
                    break;
                case ItemType.LevelExit:
                    fillingRatio = 1.0;
                    sprite = new ConsoleSprite(ConsoleColor.Blue, ConsoleColor.White, 'E');
                    break;
                case ItemType.Medikit:
                    fillingRatio = 0.0;
                    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Red, '+');
                    break;
                case ItemType.ToxicWaste:
                    fillingRatio = 0.0;
                    sprite = new ConsoleSprite(ConsoleColor.DarkGreen, ConsoleColor.Green, ':');
                    break;
                case ItemType.Wall:
                    // Teli szürke csempe: a karakter szóköz, csak a háttérszín látszik.
                    fillingRatio = 1.0;
                    sprite = new ConsoleSprite(ConsoleColor.DarkGray, ConsoleColor.DarkGray, ' ');
                    break;
            }
        }

        // Mi történik, ha a játékos (vagy egy démon) kapcsolatba lép az elemmel.
        public void Interact()
        {
            switch (type)
            {
                // Egymás alatti case-ek: mindhárom esetben ugyanaz történik, a játékos felvette.
                case ItemType.Ammo:
                case ItemType.BFGCell:
                case ItemType.Medikit:
                    available = false;
                    break;
                // Az ajtó váltakozik: a zártból nyitott lesz, a nyitottból zárt, és a kinézete is változik.
                // Az == itt biztonságos, mert a tényező mindig pontosan 1.0 vagy 0.0 (mi állítjuk be).
                case ItemType.Door:
                    if (fillingRatio == 1.0)
                    {
                        fillingRatio = 0.0;
                        sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.DarkYellow, '/');
                    }
                    else
                    {
                        fillingRatio = 1.0;
                        sprite = new ConsoleSprite(ConsoleColor.DarkYellow, ConsoleColor.Black, '/');
                    }
                    break;
            }
        }
    }
}
