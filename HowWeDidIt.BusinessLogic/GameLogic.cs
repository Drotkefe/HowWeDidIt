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
        public IGameModel GameModel { get; set; }

        public event EventHandler CallRefresh;        

        public GameLogic(string caveManName, IGameRepository gameRepository, IGameModel gameModel, IGameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            this.gameRepository = gameRepository;
            this.GameModel = gameModel;            
            var currentCaveMan = gameRepository.GetCaveManByName(caveManName);
            GameModel.CaveMan = currentCaveMan;
        }

        public bool Move(double dx, double dy)
        {
            bool entrance = false;
            if(dx == -14)
            {
                GameModel.CaveMan.Orientation = Core.Enums.Orientations.Left;
            }
            if(dx== 14)
            {
                GameModel.CaveMan.Orientation=Core.Enums.Orientations.Right;
            }
            var newX = GameModel.CaveMan.X + dx;
            if (newX > 80 && newX < GameModel.GameAreaWidth-10)
            {
                GameModel.CaveMan.X = newX;
                if (newX <= 100)//entering cave
                {
                    entrance = true;
                }
            }
            GameModel.CaveMan.MovementState = (GameModel.CaveMan.MovementState + 1) % gameSettings.MaximalAllowedMovementState;

            //Thread.Sleep(70); ezt kitöröltem, mert úgy nézett ki, hogy amíg az ősember futott a hozzávalók megálltak esésükben 

            CallRefresh?.Invoke(this, EventArgs.Empty);
            return entrance;

        }

        public void FoodItemsFalling()
        {
            foreach (var foodItem in GameModel.FallingFoods)
            {
                foodItem.Y += gameSettings.FoodItemYVelocity * rnd.Next(10, 31) / 10;

                if (foodItem.Y >= 340 )
                {                    
                    foodItem.X = rnd.Next(GameModel.CollectionAreaBeginning, GameModel.CollectionAreaEnd);
                    foodItem.Y = 0;
                    foodItem.Name = (Core.Enums.Foods)rnd.Next(0, GameModel.Recipe.FoodItems.Count);
                }
            }
        }

        public void FoodItemCaught(MovingFoodItem foodItem)
        {
            if (!GameModel.Recipe.FoodItems.Contains(foodItem.Name)) // if not in the recipe, Garbage count is up
            {
                GameModel.GarbageCount++;
            }
            else // it contained in the recipe
            {
                if (!GameModel.CollectedFoods.ContainsKey(foodItem.Name)) // but not yet on the collectedFoods list, add to list
                {
                    GameModel.CollectedFoods.Add(foodItem.Name, 1);
                }
                else // if on the list
                {
                    if (GameModel.CollectedFoods[foodItem.Name] < GameModel.FoodCapacities[foodItem.Name]) // but not enough
                    {
                        GameModel.CollectedFoods[foodItem.Name]++;
                    }
                    else // if no more is needed
                    {
                        GameModel.GarbageCount++;
                    }
                }
            }
        }
        public void Save()
        {
            gameRepository.StoreCaveMan(GameModel.CaveMan);
        }
    }
}
