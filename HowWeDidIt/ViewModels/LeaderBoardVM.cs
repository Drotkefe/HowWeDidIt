using GalaSoft.MvvmLight;
using HowWeDidIt.Core.Models;
using HowWeDidIt.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.ViewModels
{
    public class LeaderBoardVM : ViewModelBase
    {
        private Player player;

        public Player Player
        {
            get { return player; }
            set { Set(ref player, value); }
        }

        public ObservableCollection<Player> Players { get; set; }

        readonly IGameRepository gameRepository;

        public LeaderBoardVM(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;

            if (IsInDesignMode)
            {
                Players.Add(new Player(150, "Maci"));
                Players.Add(new Player(550, "Laci"));
            }
            else
            {
                var storedPlayers = gameRepository.GetLeaderBoard();
                foreach (var p in storedPlayers.players)
                {
                    Players.Add(p);
                }
            }

            

        }

        public LeaderBoardVM()
        {

        }
    }
}
