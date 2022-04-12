using GalaSoft.MvvmLight;
using HowWeDidIt.Core.Enums;
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
                    new List<Foods>(),       //foodItems
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

            //CookingFoodItem onion = new CookingFoodItem(Core.Enums.Foods.Onion);
            //CookingFoodItem carrot = new CookingFoodItem(Core.Enums.Foods.Carrot);
            //CookingFoodItem potato = new CookingFoodItem(Core.Enums.Foods.Potato);
            //CookingFoodItem meat = new CookingFoodItem(Core.Enums.Foods.Meat);
            //CookingFoodItem egg = new CookingFoodItem(Core.Enums.Foods.Egg);
            //CookingFoodItem uranium = new CookingFoodItem(Core.Enums.Foods.Uranium);

            vm.Recipe.FoodItems.Add(Core.Enums.Foods.Onion);
            vm.Recipe.FoodItems.Add(Core.Enums.Foods.Meat);
            vm.Recipe.FoodItems.Add(Core.Enums.Foods.Carrot);
            vm.Recipe.FoodItems.Add(Core.Enums.Foods.Egg);
            vm.Recipe.FoodItems.Add(Core.Enums.Foods.Potato);
            vm.Recipe.FoodItems.Add(Core.Enums.Foods.Uranium);
            vm.Recipe.FoodItems.Add(Core.Enums.Foods.Uranium);

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
