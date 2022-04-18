using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
//using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Command;
using HowWeDidIt.BusinessLogic;
using HowWeDidIt.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace HowWeDidIt.ViewModels
{
    public class KitchenScreenWindowVM : ObservableObject
    {

        private  IGameModel GM { get; }

        // ingredients to IngredientsVM for better readability:
        public IngredientsVM Ingredients { get; }
        public RecipeVM Recipe { get; }


        public int GameScore
        {
            get { return GM?.GameScore ?? 0; }
            set
            {
                SetProperty(GM.GameScore, value, GM, (gm, val) => gm.GameScore = val);
            }
        }

        public int Vitality
        {
            get { return GM?.Vitality ?? 0; }
            set
            {
                SetProperty(GM.Vitality, value, GM, (gm, val) => gm.Vitality = val);
            }
        }

        public int Money
        {
            get { return GM?.Money ?? 0; }
            set
            {
                SetProperty(GM.Money, value, GM, (gm, val) => gm.Money = val);
            }
        }

        public int GarbageCount
        {
            get { return GM?.GarbageCount ?? 0; }
            set
            {
                SetProperty(GM.GarbageCount, value, GM, (gm, val) => gm.GarbageCount = val);
            }
        }

        public int GarbageCapacity
        {
            get { return GM?.GarbageCapacity ?? 0; }
            set
            {
                SetProperty(GM.GarbageCapacity, value, GM, (gm, val) => gm.GarbageCapacity = val);
            }
        }



        readonly IKitchenService kitchenService;
        public ICommand RestoreHealthPointsCommand { get; private set; }
        public ICommand SellProductCommand { get; set; }
        public ICommand FoodToPotCommand { get; set; }

        public ICommand UpgradeStorageCommand { get; set; }


        //public KitchenScreenWindowVM()
        //{
        //    //teszthez majd használható:
        //    //this.gm = new KitchenModel()
        //    //{
        //    //    Recipe = new Recipe(
        //    //        "Pizza",                    //name
        //    //        new List<Foods>(),       //foodItems
        //    //        TimeSpan.FromSeconds(180),  //cooingTime
        //    //        false,                      //Iscooced
        //    //        50,                         //recipeScoere
        //    //        1,                          //vitalityValue
        //    //        100),                       //moneyValue

            //    //    CollectedFoods = new Dictionary<Core.Enums.Foods, int>(),
            //    //    FoodCapacities = new Dictionary<Core.Enums.Foods, int>(),
            //    //    GameScore = 1234567890,
            //    //    GarbageCapacity = 10,
            //    //    GarbageCount = 0,
            //    //    Money = 30,
            //    //    Vitality = 70
            //    //};

            //    //CookingFoodItem onion = new CookingFoodItem(Core.Enums.Foods.Onion);
            //    //CookingFoodItem carrot = new CookingFoodItem(Core.Enums.Foods.Carrot);
            //    //CookingFoodItem potato = new CookingFoodItem(Core.Enums.Foods.Potato);
            //    //CookingFoodItem meat = new CookingFoodItem(Core.Enums.Foods.Meat);
            //    //CookingFoodItem egg = new CookingFoodItem(Core.Enums.Foods.Egg);
            //    //CookingFoodItem uranium = new CookingFoodItem(Core.Enums.Foods.Uranium);

            //    //gm.Recipe.FoodList.Add(Core.Enums.Foods.Onion);
            //    //gm.Recipe.FoodList.Add(Core.Enums.Foods.Meat);
            //    //gm.Recipe.FoodList.Add(Core.Enums.Foods.Carrot);
            //    //gm.Recipe.FoodList.Add(Core.Enums.Foods.Egg);
            //    //gm.Recipe.FoodList.Add(Core.Enums.Foods.Potato);
            //    //gm.Recipe.FoodList.Add(Core.Enums.Foods.Uranium);
            //    //gm.Recipe.FoodList.Add(Core.Enums.Foods.Uranium);

            //    //ingredients = new IngredientsVM()
            //    //{
            //    //    CarrotCapacity = 6,
            //    //    OnionCapacity = 6,
            //    //    PotatoCapacity = 6,
            //    //    EggCapacity = 8,
            //    //    MeatCapacity = 8,
            //    //    UraniumCapacity = 8,

            //    //    CarrotCount = 2,
            //    //    OnionCount = 2,
            //    //    PotatoCount = 2,
            //    //    EggCount = 2,
            //    //    MeatCount = 2,
            //    //    UraniumCount = 2
            //    //};
            //}

        public KitchenScreenWindowVM()
        {

        }

        public KitchenScreenWindowVM(IGameModel model)
        {

            this.GM = model;
            Ingredients = new IngredientsVM(model.CollectedFoods, model.FoodCapacities)
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
            Recipe = new RecipeVM(model.Recipe);


            this.kitchenService = ServiceLocator.Current.GetInstance<IKitchenService>();


            RestoreHealthPointsCommand = new RelayCommand(() =>
            {
                kitchenService.RestoreHeathPoits(GM);
                OnPropertyChanged(nameof(Vitality));
                OnPropertyChanged(nameof(Recipe));
                //OnPropertyChanged(nameof(Pot));

            }, true);

            SellProductCommand = new RelayCommand(() =>
            {
                kitchenService.SellProduct(GM);
                OnPropertyChanged(nameof(Money));
                OnPropertyChanged(nameof(Recipe));
                //OnPropertyChanged(nameof(Pot));
            }, true);


            FoodToPotCommand = new RelayCommand<string>((string typeOfFood) =>
            {
                kitchenService.FoodToPot(typeOfFood, GM);
                OnPropertyChanged(nameof(Ingredients));
                OnPropertyChanged(nameof(GM.GarbageCapacity));
                OnPropertyChanged(nameof(GM.Recipe.CurrentFoodIndex));
                OnPropertyChanged(nameof(Recipe.CurrentFood));
                OnPropertyChanged(nameof(Recipe.FoodList));
                OnPropertyChanged(nameof(Recipe));



            }, true);


            UpgradeStorageCommand = new RelayCommand<string> ((string typeOfCapacity) =>
            {
                kitchenService.UpgradeStorage(typeOfCapacity, GM);
                //OnPropertyChanged(nameof(Vitality));
                OnPropertyChanged(nameof(Ingredients));
                OnPropertyChanged(nameof(GM.GarbageCapacity));
                OnPropertyChanged(nameof(GM.Money));
                //OnPropertyChanged(nameof(Pot));
                
            }, true);
        }

    }
}
