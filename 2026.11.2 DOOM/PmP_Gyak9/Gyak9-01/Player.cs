namespace ConsoleSlayer
{
    internal class Player
    {
        private Position position;
        private ConsoleSprite sprite;
        private double fillingRatio;

        // A harchoz szükséges állapot
        private int health;
        private int ammo;
        private int bfgCells;
        private bool alive;
        private int combatPoints;
        private int sightRange;

        public Player(int x, int y)
        {
            position = new Position(x, y);
            sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'O');
            fillingRatio = 0.4;

            health = 100;
            ammo = 10;
            bfgCells = 0;
            alive = true;
            combatPoints = 0;
            sightRange = 8;
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

        public double FillingRatio
        {
            get { return fillingRatio; }
        }

        public int MaxHealth
        {
            get { return 100 + combatPoints / 10; }
        }

        public int MaxAmmo
        {
            get { return 10 + combatPoints / 50; }
        }

        // A maximális energiacellák száma mindig 3.
        public int MaxBFGCells
        {
            get { return 3; }
        }

        public int Health
        {
            get { return health; }
            set
            {
                if (value > MaxHealth)
                {
                    health = MaxHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public int Ammo
        {
            get { return ammo; }
            set
            {
                if (value > MaxAmmo)
                {
                    ammo = MaxAmmo;
                }
                else if (value < 0)
                {
                    ammo = 0;
                }
                else
                {
                    ammo = value;
                }
            }
        }

        // A játékosnál lévő energiacellák száma.
        public int BFGCells
        {
            get { return bfgCells; }
            set
            {
                if (value > MaxBFGCells)
                {
                    bfgCells = MaxBFGCells;
                }
                else if (value < 0)
                {
                    bfgCells = 0;
                }
                else
                {
                    bfgCells = value;
                }
            }
        }

        public bool Alive
        {
            get { return alive; }
        }

        public int CombatPoints
        {
            get { return combatPoints; }
        }

        public int SightRange
        {
            get { return sightRange; }
        }

        public void Shoot()
        {
            Ammo--;
        }

        // BFG elsütése: egy energiacella elfogy.
        public void ShootBFG()
        {
            BFGCells--;
        }

        public void AddCombatPoints(int points)
        {
            combatPoints += points;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (health == 0)
            {
                alive = false;
            }
        }

        public void PickUpAmmo(int amount)
        {
            Ammo += amount;
        }

        // Energicella felvétele.
        public void PickUpBFGCell(int amount)
        {
            BFGCells += amount;
        }

        public void PickUpHealth(int amount)
        {
            Health += amount;
        }
    }
}