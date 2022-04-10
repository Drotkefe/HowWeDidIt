using GalaSoft.MvvmLight;
using HowWeDidIt.Core.Models;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HowWeDidIt.ViewModels
{
    public class KitchenScreenControlVM : ViewModelBase
    {
        private IKitchenModel player;

        public int PotatoCount { get; set; }
        public int EggCount { get; set; }
        public int MeatCount { get; set; }
        public int CarrotCount { get; set; }
        public int UranCount { get; set; }


        public IKitchenModel Player
        {
            get { return player; }
            set { player = value; }
        }


        public KitchenScreenControlVM()
        {
                
        }
        public KitchenScreenControlVM(IKitchenModel player)
        {
            this.player = player;
        }

    }
}
