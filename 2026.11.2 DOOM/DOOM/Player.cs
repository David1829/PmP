using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOOM
{
    internal class Player
    {
        public Position Position {  get; set; }
        public ConsoleSprite Sprite { get; set; }

        public double FillingRatio { get; private set; }

        public Player(int x, int y)
        {
            Position = new Position(x, y);
            Sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'O');
            FillingRatio = 0.4;
        }
    }
}
