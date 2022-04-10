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
    public class KitchenScreenWindowVM : ViewModelBase
    {
        private IKitchenModel player;
        public IKitchenModel Player
        {
            get { return player; }
            set { player = value; }
        }

        private IngredientsVM ingredients;
        public IngredientsVM Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }


        public KitchenScreenWindowVM()
        {
                
        }
        public KitchenScreenWindowVM(IKitchenModel model)
        {

            this.player = model;
            ingredients = new IngredientsVM()
            {
                CarrotCapacity = model.FoodCapacities[Core.Enums.Foods.Carrot],
                OnionCapacity = model.FoodCapacities[Core.Enums.Foods.Onion],
                PotatoCapacity = model.FoodCapacities[Core.Enums.Foods.Potato],
                EggCapacity = model.FoodCapacities[Core.Enums.Foods.Egg],
                MeatCapacity = model.FoodCapacities[Core.Enums.Foods.Meat],
                UraniumCapacity = model.FoodCapacities[Core.Enums.Foods.Uranium],

                CarrotCount = model.CollectedFoods[Core.Enums.Foods.Carrot],
                OnionCount = model.CollectedFoods[Core.Enums.Foods.Onion],
                PotatoCount = model.CollectedFoods[Core.Enums.Foods.Potato],
                EggCount = model.CollectedFoods[Core.Enums.Foods.Egg],
                MeatCount = model.CollectedFoods[Core.Enums.Foods.Meat],
                UraniumCount = model.CollectedFoods[Core.Enums.Foods.Uranium]
            };
        }

    }
}
