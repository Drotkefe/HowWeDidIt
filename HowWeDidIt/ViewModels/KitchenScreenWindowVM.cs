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
        private IKitchenModel vm;
        public IKitchenModel VM
        {
            get { return vm; }
            set { Set(ref vm, value); }
        }

        private IngredientsVM ingredients;
        public IngredientsVM Ingredients
        {
            get { return ingredients; }
            set { Set(ref ingredients, value); }
        }


        public KitchenScreenWindowVM()
        {
            //teszthez majd használható:
            this.vm = new KitchenModel()
            {
                Recipe = new Recipe(
                    "Pizza",                    //name
                    new List<FoodItem>(),       //foodItems
                    TimeSpan.FromSeconds(180),  //cooingTime
                    false,                      //Iscooced
                    50,                         //recipeScoere
                    1,                          //vitalityValue
                    100),                       //moneyValue

                CollectedFoods = new Dictionary<Core.Enums.Foods, int>(),
                FoodCapacities = new Dictionary<Core.Enums.Foods, int>(),
                GameScore = 1234567890,
                GarbageCapacity = 10,
                GarbageCount = 0,
                Money = 30,
                Vitality = 70
            };

            FoodItem onion = new FoodItem(Core.Enums.Foods.Onion, 1, 2);
            FoodItem carrot = new FoodItem(Core.Enums.Foods.Carrot, 1, 2);
            FoodItem potato = new FoodItem(Core.Enums.Foods.Potato, 1, 3);
            FoodItem meat = new FoodItem(Core.Enums.Foods.Meat, 3, 5);
            FoodItem egg = new FoodItem(Core.Enums.Foods.Egg, 1, 2);
            FoodItem uranium = new FoodItem(Core.Enums.Foods.Uranium, 0, 0);

            vm.Recipe.FoodItems.Add(onion);
            vm.Recipe.FoodItems.Add(meat);
            vm.Recipe.FoodItems.Add(carrot);
            vm.Recipe.FoodItems.Add(egg);
            vm.Recipe.FoodItems.Add(potato);
            vm.Recipe.FoodItems.Add(uranium);
            vm.Recipe.FoodItems.Add(uranium);

            //ingredients = new IngredientsVM()
            //{
            //    CarrotCapacity = 6,
            //    OnionCapacity = 6,
            //    PotatoCapacity = 6,
            //    EggCapacity = 8,
            //    MeatCapacity = 8,
            //    UraniumCapacity = 8,

            //    CarrotCount = 2,
            //    OnionCount = 2,
            //    PotatoCount = 2,
            //    EggCount = 2,
            //    MeatCount = 2,
            //    UraniumCount = 2
            //};
        }
        public KitchenScreenWindowVM(IKitchenModel model)
        {

            //this.vm = model;
            //ingredients = new IngredientsVM()
            //{
            //    CarrotCapacity = model.FoodCapacities[Core.Enums.Foods.Carrot],
            //    OnionCapacity = model.FoodCapacities[Core.Enums.Foods.Onion],
            //    PotatoCapacity = model.FoodCapacities[Core.Enums.Foods.Potato],
            //    EggCapacity = model.FoodCapacities[Core.Enums.Foods.Egg],
            //    MeatCapacity = model.FoodCapacities[Core.Enums.Foods.Meat],
            //    UraniumCapacity = model.FoodCapacities[Core.Enums.Foods.Uranium],

            //    CarrotCount = model.CollectedFoods[Core.Enums.Foods.Carrot],
            //    OnionCount = model.CollectedFoods[Core.Enums.Foods.Onion],
            //    PotatoCount = model.CollectedFoods[Core.Enums.Foods.Potato],
            //    EggCount = model.CollectedFoods[Core.Enums.Foods.Egg],
            //    MeatCount = model.CollectedFoods[Core.Enums.Foods.Meat],
            //    UraniumCount = model.CollectedFoods[Core.Enums.Foods.Uranium]
            //};
        }

    }
}
