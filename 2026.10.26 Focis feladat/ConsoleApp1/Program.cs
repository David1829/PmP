
using ConsoleApp1.Enums;

namespace ConsoleApp1
{
    internal class Program
    {

        static string[] SecondNames = new string[] { "Skywalker", "Smith", "Tailor", "Balage" };
        static string[] FirstNames = new string[] { "Anakin", "Bob", "Elemer", "Leia" };
        static void Main(string[] args)
        {
            Player[] availablePlayers = RandomPlayers(10);
            Team team = new Team();

            do
            {
                Console.Clear();
                Console.WriteLine("Available players: ");
                DisplayPlayers(availablePlayers);

                Console.WriteLine("Team Members: ");
                DisplayPlayers(team.Players);

                Console.Write("Choose the player by idx: ");
                int idx = int.Parse(Console.ReadLine());

                team.Include(availablePlayers[idx]);
            } while (!team.IsFull);

            Console.Clear();
            DisplayPlayers(team.Players);
        }

        private static void DisplayPlayers(Player[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, players[i]);
                Console.WriteLine();
            }
        }

        private static Player[] RandomPlayers(int count)
        {
            Random rnd = new Random();
            Player[] result = new Player[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new Player($"{FirstNames[rnd.Next(0,FirstNames.Length)]} {SecondNames[rnd.Next(0,SecondNames.Length)]}", (Position)rnd.Next(0, Enum.GetNames(typeof(Position)).Length));
            }

            return result;
        }
    }
}
