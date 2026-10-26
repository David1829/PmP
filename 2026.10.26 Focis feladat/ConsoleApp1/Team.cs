using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Team
    {
        private Player[] players;

        public Player[] Players => players;

        public int NumberOfPlayers
        {
            get
            {
                int cnt = 0;
                foreach (Player p in players)
                {
                    if (p != null)
                    {
                        cnt++;
                    }
                }
                return cnt;
            }
        }

        public bool IsFull => NumberOfPlayers == players.Length;

        public Team()
        {
            players = new Player[5];
        }

        public bool IsIncluded(Player player)
        {
            int idx = 0;
            while (idx < players.Length && !(players[idx] != null && players[idx].Name == player.Name && players[idx].Position == player.Position))
            {
                idx++;
            }
            return idx < players.Length;
        }
        public bool IsAvailable(Player player)
        {
            int[] stat = GetPositionStatistic();
            switch (player.Position)
            {
                case Position.Goalkeeper:
                case Position.Forward:
                case Position.Defender:
                    return stat[(int)player.Position] < 1;
                case Position.Winger:
                    return stat[(int)player.Position] < 2;
                default:
                    return false;
            }
        }

        public void Include(Player player)
        {
            if (IsFull || IsIncluded(player) || !IsAvailable(player))
            { 
                return; 
            }

            int idx = 0;

            while (players[idx] != null)
            {
                idx++;
            }

            players[idx] = player;
        }

        private int[] GetPositionStatistic()
        {
            int[] result = new int[Enum.GetNames(typeof(Position)).Length];

            foreach (Player p in players)
            {
                if (p != null)
                {
                    result[(int)p.Position]++;
                }

                
            }
            return result;
        }
    }
}
