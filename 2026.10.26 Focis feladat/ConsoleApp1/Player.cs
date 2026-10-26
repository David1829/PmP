using ConsoleApp1.Enums;

namespace ConsoleApp1
{
    public class Player
    {
        private string name;
        Position pos;

        public string Name => name;
        public Position Position => pos;

        public Player(string name, Position pos)
        {
            this.name = name;
            this.pos = pos;
        }
        public override string ToString()
        {
            return $"Name: {name}\nPosition: {pos}";
        }

    }
}
