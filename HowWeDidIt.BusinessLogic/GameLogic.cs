using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.Models;
using HowWeDidIt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HowWeDidIt.BusinessLogic
{
    public class GameLogic : IGameLogic
    {
        Random rnd = new Random();
        readonly IGameRepository gameRepository;
        readonly IGameSettings gameSettings;
        readonly IKitchenService kitchenService;
        public IGameModel GameModel { get; private set; }
        public Recipe recipe; 

        public event EventHandler CallRefresh;

        public GameLogic(IGameModel gameModel, IGameSettings gameSettings, IGameRepository gameRepository, IKitchenService kitchenService)
        {
            this.gameRepository = gameRepository;
            this.gameSettings = gameSettings;
            this.GameModel = gameModel;
            this.kitchenService = kitchenService;
            //InitRecipe();
        }

        public void InitRecipe()
        {
            GameModel.Recipe = kitchenService.NewRecipe();
            GetCapacities();
        }

        public bool Move(double dx, double dy)
        {
            bool entrance = false;
            if (dx == -14)
            {
                GameModel.CaveMan.Orientation = Core.Enums.Orientations.Left;
            }
            if (dx == 14)
            {
                GameModel.CaveMan.Orientation = Core.Enums.Orientations.Right;
            }
            var newX = GameModel.CaveMan.X + dx;
            if (newX > 80 && newX < GameModel.GameAreaWidth - 60)
            {
                GameModel.CaveMan.X = newX;
                if (newX <= 100)//entering cave
                {
                    entrance = true;
                }
                if (newX >= 650)
                {
                    GameModel.GarbageCount = 0;
                }
            }
            GameModel.CaveMan.MovementState = (GameModel.CaveMan.MovementState + 1) % gameSettings.MaximalAllowedMovementState;

            CallRefresh?.Invoke(this, EventArgs.Empty);
            return entrance;

        }

        public void FoodItemsFalling()
        {
            foreach (var foodItem in GameModel.FoodItems)
            {
                foodItem.Y += gameSettings.FoodItemYVelocity * rnd.Next(10, 31) / 10;

                if (foodItem.Y >= 340)
                {
                    foodItem.X = rnd.Next(GameModel.CollectionAreaBeginning, GameModel.CollectionAreaEnd);
                    foodItem.Y = 0;
                    foodItem.Name = (Core.Enums.Foods)rnd.Next(0, 6);
                }
            }
        }
        public void GetCapacities()
        {            
            List<Foods> distinctFoodList = GameModel.Recipe.FoodList.Select(x => x).Distinct().ToList();
            
            int idx = 0;
            foreach (var food in distinctFoodList)
            {
                idx = GameModel.Recipe.FoodList.Where(x => x == food).Count();
                GameModel.FoodCapacities.Add(food, idx);
                GameModel.CollectedFoods.Add(food, 0);
            }            
        }
        public void FoodItemCaught(MovingFoodItem foodItem)
        {
            
            //GameModel.CollectedFoods[foodItem.Name]++;

            if (!GameModel.Recipe.FoodList.Contains(foodItem.Name)) // if not in the recipe, Garbage count is up
            {
                return;
                //GameModel.GarbageCount++;
            }
            //else // it contained in the recipe
            //{
            //if (!GameModel.CollectedFoods.ContainsKey(foodItem.Name)) // but not yet on the collectedFoods list, add to list
            //{
            //    GameModel.CollectedFoods.Add(foodItem.Name, 1);
            //}
            else // if on the list
            //{
                if (GameModel.CollectedFoods[foodItem.Name] < GameModel.FoodCapacities[foodItem.Name]) // but not enough
                {
                    GameModel.CollectedFoods[foodItem.Name]++;
                }
                //else // if no more is needed
                //{
                //    GameModel.GarbageCount++;
                //}
            //}
        }

        public void DecreaseHealth()
        {            
            GameModel.Vitality--;
        }

        public void Save(IGameModel gameModel)
        {
            gameRepository.StoreGameModel(gameModel);
        }
    }
}
