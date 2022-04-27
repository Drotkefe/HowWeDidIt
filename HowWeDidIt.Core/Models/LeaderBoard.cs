
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.Models
{
    public class LeaderBoard:ObservableObject
    {
        public List<Player> players { get; set; }

        public LeaderBoard()
        {
            players = new List<Player>();
        }

        

    }
}
