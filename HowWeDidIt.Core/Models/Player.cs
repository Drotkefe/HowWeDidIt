using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.Models
{
    public class Player: ObservableObject
    {
        private int score;

        public int Score
        {
            get { return score; }
            set { Set(ref score , value); }
        }

        private string player_name;

        public string Player_Name
        {
            get { return player_name; }
            set { Set(ref player_name, value); }
        }

        public Player()
        {

        }

        public Player(int score, string player_Name)
        {
            Score = score;
            Player_Name = player_Name;
        }

        public Player(Player other)
        {
            score = other.score;
            player_name = other.player_name;
        }
    }
}
