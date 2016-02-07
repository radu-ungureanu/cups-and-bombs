using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupsAndBombs.Models
{
    class Player
    {
        public string Name;
        public int Score;

        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}
