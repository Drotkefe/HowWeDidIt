using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.GameSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Models
{
    public class GameModel : IGameModel
    {
        static Random rnd = new Random();

        public double GameAreaHeight { get; set; }
        public double GameAreaWidth { get; set; }

        public MovingCaveMan CaveMan { get; private set; }
        public Recipe Recipe { get; private set; }
        public Dictionary<Foods, int> FoodCapacities { get; set; }
        public Dictionary<Foods, int> CollectedFoods { get; set; }
        public int GarbageCount { get; set; }
        public int GarbageCapacity { get; set; }
        public int Vitality { get; set; }
        public int Money { get; set; }
        public int GameScore { get; set; }

        public List<MovingFoodItem> FoodItems { get; private set; }        
        public int CollectionAreaBeginning { get; set; }
        public int CollectionAreaEnd { get; set; }

        public GameModel(double gameAreaWidth, double gameAreaHeight, IGameSettings gameSettings)
        {
            GameAreaWidth = gameAreaWidth;
            GameAreaHeight = gameAreaHeight;
            FoodItems = new List<MovingFoodItem>();

            CollectionAreaBeginning = (int)gameAreaWidth / 4;
            CollectionAreaEnd = (int)gameAreaWidth - 50;

            InitDefaultValues(gameSettings, gameAreaWidth, gameAreaHeight);
        }

        private void InitDefaultValues(IGameSettings gameSettings, double gameAreaWidth, double gameAreaHeight)
        {
            CaveMan = new MovingCaveMan(gameSettings.CaveManInitXPosition, gameSettings.CaveManInitYPosition, gameSettings.CaveManInitXVelocity, gameSettings.CaveManInitYVelocity);

            for (int i = 0; i < gameSettings.FoodItemCount; i++)
            {                               
                FoodItems.Add(new MovingFoodItem((Foods)rnd.Next(0, 6), rnd.Next(CollectionAreaBeginning, CollectionAreaEnd), 0, 0, gameSettings.FoodItemYVelocity));
            }



            FoodCapacities = new Dictionary<Foods, int>();
            FoodCapacities.Add(Foods.Carrot, 2);
            FoodCapacities.Add(Foods.Egg, 2);
            FoodCapacities.Add(Foods.Meat, 2);
            FoodCapacities.Add(Foods.Onion, 2);
            FoodCapacities.Add(Foods.Potato, 2);
            FoodCapacities.Add(Foods.Uranium, 2);

            CollectedFoods = new Dictionary<Foods, int>();


            CollectedFoods.Add(Foods.Carrot, 1);
            CollectedFoods.Add(Foods.Egg, 1);
            CollectedFoods.Add(Foods.Meat, 1);
            CollectedFoods.Add(Foods.Onion, 1);
            CollectedFoods.Add(Foods.Potato, 1);
            CollectedFoods.Add(Foods.Uranium, 1);

            GarbageCount = 0;
            GarbageCapacity = 10;
            Vitality = 90;
            Money = 20;
            GameScore = 0;

            Recipe.Name = "Pizza";
            Recipe.FoodItems = new List<Foods>();
            Recipe.FoodItems.Add(Core.Enums.Foods.Onion);
            Recipe.FoodItems.Add(Core.Enums.Foods.Meat);
            Recipe.FoodItems.Add(Core.Enums.Foods.Carrot);
            Recipe.FoodItems.Add(Core.Enums.Foods.Egg);
            Recipe.FoodItems.Add(Core.Enums.Foods.Potato);
            Recipe.FoodItems.Add(Core.Enums.Foods.Uranium);
            Recipe.FoodItems.Add(Core.Enums.Foods.Uranium);
            Recipe.Cooked = false;
            Recipe.CookingTime = TimeSpan.FromSeconds(180);
            Recipe.MoneyValue = 50;
            Recipe.RecipeScore = 100;
            Recipe.VitalityValue = 1;
            Recipe.CurrentFoodIndex = 4;
        }

        // TODO: create other ctor for load data from saved game

    }
}
