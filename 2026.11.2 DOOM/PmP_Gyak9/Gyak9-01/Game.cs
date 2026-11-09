
using System.Diagnostics;
using WMPLib;

namespace ConsoleSlayer
{
    public enum SoundEffectType
    {
        BFG,
        Door,
        ItemPickup,
        Pain,
        PlayerDeath,
        Shotgun
    }

    internal class Game
    {
        private Player player;
        private bool exited;

        private WindowsMediaPlayer musicPlayer;
        private WindowsMediaPlayer sfxPlayer;

        private List<GameItem> items;
        private List<Demon> demons;

        private ConsoleRenderer renderer;
        private GameLogic logic;

        private Stopwatch logicTimer;
        private Stopwatch renderTimer;

        public Game()
        {
            player = new Player(0, 0);
            exited = false;

            items = new List<GameItem>();
            demons = new List<Demon>();

            musicPlayer = new WindowsMediaPlayer();
            sfxPlayer = new WindowsMediaPlayer();

            renderer = new ConsoleRenderer(this);
            logic = new GameLogic(this);

            logicTimer = new Stopwatch();
            renderTimer = new Stopwatch();
        }

        public Player Player
        {
            get { return player; }
        }

        public bool Exited
        {
            get { return exited; }
            set { exited = value; }
        }

        public List<GameItem> Items
        {
            get { return items; }
        }

        public List<Demon> Demons
        {
            get { return demons; }
        }

        public WindowsMediaPlayer MusicPlayer
        {
            get { return musicPlayer; }
        }

        public WindowsMediaPlayer SfxPlayer
        {
            get { return sfxPlayer; }
        }

        // Billentyűk kezelése.
        private void UserAction()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);

                switch (pressed.Key)
                {
                    case ConsoleKey.Escape:
                        Exited = true;
                        break;

                    case ConsoleKey.UpArrow:
                        logic.Move(
                            player,
                            Position.Add(player.Position, new Position(0, -1)));
                        break;

                    case ConsoleKey.DownArrow:
                        logic.Move(
                            player,
                            Position.Add(player.Position, new Position(0, 1)));
                        break;

                    case ConsoleKey.LeftArrow:
                        logic.Move(
                            player,
                            Position.Add(player.Position, new Position(-1, 0)));
                        break;

                    case ConsoleKey.RightArrow:
                        logic.Move(
                            player,
                            Position.Add(player.Position, new Position(1, 0)));
                        break;

                    case ConsoleKey.D:
                        foreach (GameItem item in items)
                        {
                            item.Interact();
                            logic.PlayerDirectInteractionLogic();
                        }
                        break;

                    // Hagyományos lövés.
                    case ConsoleKey.A:
                        logic.PlayerAttackLogic();
                        break;

                    // BFG támadás az S billentyűvel.
                    case ConsoleKey.S:
                        logic.PlayerBFGAttackLogic();
                        break;
                }

                logic.PlayerIndirectInteractionLogic();
            }
        }

        public void LoadMapFromPlainText(string path)
        {
            string[] lines = File.ReadAllLines(path);

            string[] size = lines[0].Split(',');

            int rows = int.Parse(size[0]);
            int columns = int.Parse(size[1]);

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y + 1];

                for (int x = 0; x < columns && x < line.Length; x++)
                {
                    switch (line[x])
                    {
                        case 'A':
                            items.Add(new GameItem(x, y, ItemType.Ammo));
                            break;

                        case 'B':
                            items.Add(new GameItem(x, y, ItemType.BFGCell));
                            break;

                        case 'D':
                            items.Add(new GameItem(x, y, ItemType.Door));
                            break;

                        case 'E':
                            items.Add(new GameItem(x, y, ItemType.LevelExit));
                            break;

                        case 'M':
                            items.Add(new GameItem(x, y, ItemType.Medikit));
                            break;

                        case 'T':
                            items.Add(new GameItem(x, y, ItemType.ToxicWaste));
                            break;

                        case 'W':
                            items.Add(new GameItem(x, y, ItemType.Wall));
                            break;

                        case 'm':
                            demons.Add(new Demon(x, y, DemonType.Mancubus));
                            break;

                        case 'z':
                            demons.Add(new Demon(x, y, DemonType.Zombieman));
                            break;

                        case 'i':
                            demons.Add(new Demon(x, y, DemonType.Imp));
                            break;

                        case 'p':
                            player.Position = new Position(x, y);
                            break;

                        case '_':
                            break;
                    }
                }
            }
        }

        public void PlaySoundEffect(SoundEffectType effectType)
        {
            switch (effectType)
            {
                case SoundEffectType.BFG:
                    SfxPlayer.URL = "sound/bfg.mp3";
                    break;

                case SoundEffectType.Door:
                    SfxPlayer.URL = "sound/door.mp3";
                    break;

                case SoundEffectType.ItemPickup:
                    SfxPlayer.URL = "sound/item_pickup.mp3";
                    break;

                case SoundEffectType.Pain:
                    SfxPlayer.URL = "sound/pain.mp3";
                    break;

                case SoundEffectType.PlayerDeath:
                    SfxPlayer.URL = "sound/player_death.mp3";
                    break;

                case SoundEffectType.Shotgun:
                    SfxPlayer.URL = "sound/shotgun.mp3";
                    break;
            }

            SfxPlayer.controls.play();
        }

        public void PlayMusic(string path)
        {
            MusicPlayer.URL = path;
            MusicPlayer.controls.play();
        }

        // A játék fő ciklusa.


        public void Run()
        {
            PlayMusic("sound/background.mp3");

            logicTimer.Start();
            renderTimer.Start();

            while (!Exited && player.Alive)
            {
                if (logicTimer.ElapsedMilliseconds > 500)
                {
                    // A két logikai frissítés között eltelt idő.
                    long deltaTime = logicTimer.ElapsedMilliseconds;

                    logic.UpdateGameState(deltaTime);

                    logicTimer.Restart();
                }

                if (renderTimer.ElapsedMilliseconds > 25)
                {
                    renderer.RenderGame();
                    renderTimer.Restart();
                }

                UserAction();

                Thread.Sleep(25);
            }

            if (!player.Alive)
            {
                PlaySoundEffect(SoundEffectType.PlayerDeath);
            }
            else if (Exited)
            {
                PlayMusic("sound/victory.mp3");
            }

            Console.WriteLine("Game Over! Press Enter to exit.");
            Console.ReadLine();
        }


    }
}
