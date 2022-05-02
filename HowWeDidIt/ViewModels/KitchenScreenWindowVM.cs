using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using HowWeDidIt.BusinessLogic;
using HowWeDidIt.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace HowWeDidIt.ViewModels
{
    public class KitchenScreenWindowVM : ObservableObject
    {
        private IGameModel GM { get; }
        public IngredientsVM Ingredients { get; } // ingredientsVM property to IngredientsVM for better readability
        public RecipeVM Recipe { get; private set; }

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

        public KitchenScreenWindowVM() { }
        public KitchenScreenWindowVM(IGameModel model)
        {
            this.GM = model;
            Ingredients = new IngredientsVM(model.CollectedFoods, model.FoodCapacities)
            {
                // This is because if a food item is not on hte list, it gives a null reference exception.
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
                Recipe = new RecipeVM(model.Recipe);
                OnPropertyChanged(nameof(Vitality));
                OnPropertyChanged(nameof(Recipe));
            }, true);


            SellProductCommand = new RelayCommand(() =>
            {
                kitchenService.SellProduct(GM);
                Recipe = new RecipeVM(model.Recipe);
                OnPropertyChanged(nameof(Money));
                OnPropertyChanged(nameof(Recipe));
            }, true);


            FoodToPotCommand = new RelayCommand<string>((string typeOfFood) =>
            {
                kitchenService.FoodToPot(typeOfFood, GM);
                Recipe = new RecipeVM(model.Recipe);
                OnPropertyChanged(nameof(Ingredients));
                OnPropertyChanged(nameof(GM.GarbageCount));
                OnPropertyChanged(nameof(GM.GameScore));
                OnPropertyChanged(nameof(Recipe));
                OnPropertyChanged(nameof(Recipe.CurrentFood));
            }, true);


            UpgradeStorageCommand = new RelayCommand<string>((string typeOfCapacity) =>
           {
               kitchenService.UpgradeStorage(typeOfCapacity, GM);
               OnPropertyChanged(nameof(Ingredients));
               OnPropertyChanged(nameof(GM.GarbageCapacity));
               OnPropertyChanged(nameof(GM.Money));
           }, true);
        }


        public void DecreaseHealt()
        {
            OnPropertyChanged(nameof(GM.Vitality));
        }

    }
}
