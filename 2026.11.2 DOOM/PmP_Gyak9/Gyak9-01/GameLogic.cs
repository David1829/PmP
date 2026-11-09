
namespace ConsoleSlayer
{
    internal class GameLogic
    {
        private static Random RNG = new Random();
        private Game game;


        public GameLogic(Game game)
        {
            this.game = game;
        }

        // A játék állapotának frissítése.
        public void UpdateGameState(long deltaTime)
        {
            UpdateDemons(deltaTime);
            CleanUpGameItems();
            CleanUpDemons();
        }

        // Hagyományos lövés.
        public void PlayerAttackLogic()
        {
            if (game.Player.Ammo > 0)
            {
                game.Player.Shoot();
                game.PlaySoundEffect(SoundEffectType.Shotgun);

                foreach (Demon demon in GetDemonsWithinDistance(
                    game.Player.Position, game.Player.SightRange))
                {
                    double distance = Position.Distance(
                        game.Player.Position, demon.Position);

                    int damage = (int)(2 * RNG.Next(35, 106) / (1 + distance));

                    demon.TakeDamage(damage);
                    game.PlaySoundEffect(SoundEffectType.Pain);

                    if (!demon.Alive)
                    {
                        switch (demon.Type)
                        {
                            case DemonType.Zombieman:
                                game.Player.AddCombatPoints(1);
                                break;

                            case DemonType.Imp:
                                game.Player.AddCombatPoints(3);
                                break;

                            case DemonType.Mancubus:
                                game.Player.AddCombatPoints(10);
                                break;
                        }
                    }
                }
            }
        }

        // BFG támadás.
        public void PlayerBFGAttackLogic()
        {
            if (game.Player.BFGCells > 0)
            {
                game.Player.ShootBFG();
                game.PlaySoundEffect(SoundEffectType.BFG);

                foreach (Demon demon in GetDemonsWithinDistance(
                    game.Player.Position, game.Player.SightRange))
                {
                    int damage = RNG.Next(100, 801);

                    demon.TakeDamage(damage);
                    game.PlaySoundEffect(SoundEffectType.Pain);

                    if (!demon.Alive)
                    {
                        game.Player.AddCombatPoints(1);
                    }
                }
            }
        }

        // A démon támadása, az eltelt idő figyelembevételével.
        private void DemonAttackLogic(Demon demon, long deltaTime)
        {
            double distance = Position.Distance(
                game.Player.Position, demon.Position);

            int baseDamage = RNG.Next(
                demon.MinDamage, demon.MaxDamage + 1);

            int damage = (int)(
                2 * baseDamage / (1 + distance) *
                (deltaTime / 1000.0));

            game.Player.TakeDamage(damage);
        }

        // A játékos mozgása.
        public void Move(Player player, Position targetPosition)
        {
            if (GetTotalFillingRatio(targetPosition) +
                player.FillingRatio <= 1.0)
            {
                player.Position = targetPosition;
            }
        }

        // A démon mozgása az eltelt idő figyelembevételével.
        public void Move(Demon demon, Position targetPosition, long deltaTime)
        {
            double pMove = (demon.Speed / 100.0) *
                           (deltaTime / 1000.0);

            double randomValue = RNG.NextDouble();

            if (randomValue < pMove)
            {
                if (GetTotalFillingRatio(targetPosition) +
                    demon.FillingRatio <= 1.0)
                {
                    demon.Position = targetPosition;
                }
            }
        }

        public void PlayerDirectInteractionLogic()
        {
            foreach (GameItem item in GetGameItemsWithinDistance(
                game.Player.Position, 1))
            {
                if (item.Type == ItemType.Door)
                {
                    item.Interact();
                    game.PlaySoundEffect(SoundEffectType.Door);
                }
                else if (item.Type == ItemType.LevelExit)
                {
                    item.Interact();
                    game.Exited = true;
                }
            }
        }

        // Játékos közvetett interakciói.
        public void PlayerIndirectInteractionLogic()
        {
            foreach (GameItem item in GetGameItemsWithinDistance(
                game.Player.Position, 0))
            {
                if (item.Type == ItemType.Ammo)
                {
                    item.Interact();
                    game.Player.PickUpAmmo(5);
                    game.PlaySoundEffect(SoundEffectType.ItemPickup);
                }
                else if (item.Type == ItemType.BFGCell)
                {
                    if (game.Player.BFGCells < game.Player.MaxBFGCells)
                    {
                        item.Interact();
                        game.Player.PickUpBFGCell(1);
                        game.PlaySoundEffect(SoundEffectType.ItemPickup);
                    }
                }
                else if (item.Type == ItemType.Medikit)
                {
                    item.Interact();
                    game.Player.PickUpHealth(25);
                    game.PlaySoundEffect(SoundEffectType.ItemPickup);
                }
                else if (item.Type == ItemType.ToxicWaste)
                {
                    item.Interact();
                    game.Player.TakeDamage(5);
                    game.PlaySoundEffect(SoundEffectType.Pain);
                }
            }
        }

        public void DemonIndirectInteractionLogic(Demon demon)
        {
            foreach (GameItem item in GetGameItemsWithinDistance(
                demon.Position, 0))
            {
                if (item.Type == ItemType.ToxicWaste)
                {
                    item.Interact();
                    demon.TakeDamage(5);
                }
            }
        }

        // A démon véletlenszerű célpozíciójának meghatározása.
        private void DemonMoveLogic(Demon demon, long deltaTime)
        {
            int x = demon.Position.X + RNG.Next(-1, 2);
            int y = demon.Position.Y + RNG.Next(-1, 2);

            Position targetPosition = new Position(x, y);

            Move(demon, targetPosition, deltaTime);
        }

        // A démonok frissítése.
        private void UpdateDemons(long deltaTime)
        {
            foreach (Demon demon in game.Demons)
            {
                demon.UpdateState(game.Player);

                if (demon.State == DemonStateType.Move)
                {
                    DemonMoveLogic(demon, deltaTime);
                }
                else if (demon.State == DemonStateType.Attack)
                {
                    DemonAttackLogic(demon, deltaTime);
                }

                DemonIndirectInteractionLogic(demon);
            }
        }

        // Játékelemek keresése adott távolságon belül.
        private List<GameItem> GetGameItemsWithinDistance(
            Position position, double distance)
        {
            List<GameItem> result = new List<GameItem>();

            foreach (GameItem item in game.Items)
            {
                if (Position.Distance(item.Position, position) <= distance)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        // Démonok keresése adott távolságon belül.
        private List<Demon> GetDemonsWithinDistance(
            Position position, double distance)
        {
            List<Demon> result = new List<Demon>();

            foreach (Demon demon in game.Demons)
            {
                if (Position.Distance(demon.Position, position) <= distance)
                {
                    result.Add(demon);
                }
            }

            return result;
        }

        // Az adott csempén lévő objektumok kitöltési aránya.
        private double GetTotalFillingRatio(Position position)
        {
            double total = 0;

            foreach (GameItem item in GetGameItemsWithinDistance(position, 0))
            {
                total += item.FillingRatio;
            }

            foreach (Demon demon in GetDemonsWithinDistance(position, 0))
            {
                total += demon.FillingRatio;
            }

            return total;
        }

        // A felvett játékelemek törlése.
        private void CleanUpGameItems()
        {
            List<GameItem> toRemove = new List<GameItem>();

            foreach (GameItem item in game.Items)
            {
                if (!item.Available)
                {
                    toRemove.Add(item);
                }
            }

            foreach (GameItem item in toRemove)
            {
                game.Items.Remove(item);
            }
        }

        // A halott démonok törlése.
        private void CleanUpDemons()
        {
            List<Demon> toRemove = new List<Demon>();

            foreach (Demon demon in game.Demons)
            {
                if (!demon.Alive)
                {
                    toRemove.Add(demon);
                }
            }

            foreach (Demon demon in toRemove)
            {
                game.Demons.Remove(demon);
            }
        }
    }
}
