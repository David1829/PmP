
namespace ConsoleSlayer
{
    internal class Demon
    {
        private Position position;
        private ConsoleSprite sprite;
        private DemonType type;
        private double fillingRatio;
        private int health;
        private bool alive;
        private int sightRange;
        private int attackRange;
        private DemonStateType state;
        private int minDamage;
        private int maxDamage;
        private int speed;

        public Demon(int x, int y, DemonType type)
        {
            position = new Position(x, y);
            this.type = type;
            alive = true;
            state = DemonStateType.Idle;
            SetInitialProperties();
        }

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        public ConsoleSprite Sprite
        {
            get { return sprite; }
        }

        public DemonType Type
        {
            get { return type; }
        }

        public double FillingRatio
        {
            get { return fillingRatio; }
        }

        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public bool Alive
        {
            get { return alive; }
        }

        public int SightRange
        {
            get { return sightRange; }
        }

        public int AttackRange
        {
            get { return attackRange; }
        }

        public DemonStateType State
        {
            get { return state; }
            set { state = value; }
        }

        public int MinDamage
        {
            get { return minDamage; }
        }

        public int MaxDamage
        {
            get { return maxDamage; }
        }

        // A démon gyorsasága.
        public int Speed
        {
            get { return speed; }
        }

        private void SetInitialProperties()
        {
            switch (type)
            {
                case DemonType.Zombieman:
                    fillingRatio = 0.4;
                    health = 20;
                    sightRange = 3;
                    attackRange = 1;
                    minDamage = 3;
                    maxDamage = 15;
                    speed = 25; // Ellenőrizd a 2. táblázat alapján!
                    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Gray, 'o');
                    break;

                case DemonType.Imp:
                    fillingRatio = 0.4;
                    health = 60;
                    sightRange = 6;
                    attackRange = 3;
                    minDamage = 3;
                    maxDamage = 24;
                    speed = 50; // Ellenőrizd a 2. táblázat alapján!
                    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Red, 'o');
                    break;

                case DemonType.Mancubus:
                    fillingRatio = 0.96;
                    health = 600;
                    sightRange = 9;
                    attackRange = 6;
                    minDamage = 8;
                    maxDamage = 64;
                    speed = 25; // Ellenőrizd a 2. táblázat alapján!
                    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Magenta, 'O');
                    break;
            }
        }

        public void UpdateState(Player player)
        {
            double distance = Position.Distance(position, player.Position);

            if (distance <= attackRange)
            {
                state = DemonStateType.Attack;
            }
            else if (distance <= sightRange)
            {
                state = DemonStateType.Move;
            }
            else
            {
                state = DemonStateType.Idle;
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (health == 0)
            {
                alive = false;
            }
        }
    }
}
