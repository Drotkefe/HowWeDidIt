using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.BusinessLogic
{
    public class GameLogic : IGameLogic
    {
        //readonly IGameRepository gameRepository;
        readonly IGameSettings gameSettings;
        public IGameModel GameModel { get; private set; }

        public event EventHandler CallRefresh;

        public GameLogic(IGameSettings gameSettings)
        {
           
            this.gameSettings = gameSettings;
            

            

        }

        public void Move(double dx, double dy)
        {
            var newX = GameModel.CaveMan.X + dx;
            if (newX > 200 && newX < GameModel.GameAreaWidth-10)
            {
                GameModel.CaveMan.X = newX;
            }
            GameModel.CaveMan.MovementState = (GameModel.CaveMan.MovementState + 1) % gameSettings.MaximalAllowedMovementState;
            CallRefresh?.Invoke(this, EventArgs.Empty);

        }
    }
}
