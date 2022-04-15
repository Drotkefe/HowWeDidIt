using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.Models;
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
        //readonly IGameRepository gameRepository;
        readonly IGameSettings gameSettings;
        public IGameModel GameModel { get; private set; }

        public event EventHandler CallRefresh;

        public GameLogic(IGameModel gameModel,IGameSettings gameSettings)
        {
           
            this.gameSettings = gameSettings;
            this.GameModel = gameModel;
            

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
            Thread.Sleep(70);
            CallRefresh?.Invoke(this, EventArgs.Empty);
            return entrance;

        }

        public void FoodItemsFalling()
        {
            foreach (var foodItem in GameModel.FoodItems)
            {
                foodItem.Y -= gameSettings.FoodItemYVelocity;

                if (foodItem.Y > 321 )
                {
                    //Thread.Sleep(rnd.Next(0, 2500));
                    foodItem.X = rnd.Next(GameModel.CollectionAreaBeginning, GameModel.CollectionAreaEnd);
                    foodItem.Y = 0;
                }
            }
        }

        public void FoodItemCaught()
        {
            throw new NotImplementedException();
        }
    }
}
