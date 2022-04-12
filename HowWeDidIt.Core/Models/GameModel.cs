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
        public double GameAreaHeight { get; set; }
        public double GameAreaWidth { get; set; }


        public CaveManMovement CaveMan { get; private set; }
        public Recipe Recipe { get; private set; }
        public Dictionary<Foods, int> FoodCapacities { get; set; }
        public Dictionary<Foods, int> CollectedFoods { get; set; }
        public int GarbageCount { get; set; }
        public int GarbageCapacity { get; set; }
        public int Vitality { get; set; }
        public int Money { get; set; }
        public int GameScore { get; set; }






        public GameModel(double gameAreaWidth, double gameAreaHeight, IGameSettings gameSettings)
        {
            GameAreaWidth = gameAreaWidth;
            GameAreaHeight = gameAreaHeight;
            InitDefaultValues(gameSettings, gameAreaWidth, gameAreaHeight);
            FoodCapacities = new Dictionary<Foods, int>();
            CollectedFoods = new Dictionary<Foods, int>();
        }

        private void InitDefaultValues(IGameSettings gameSettings, double gameAreaWidth, double gameAreaHeight)
        {
            CaveMan = new CaveManMovement(gameSettings.CaveManInitXPosition, gameSettings.CaveManInitYPosition, gameSettings.CaveManInitXVelocity, gameSettings.CaveManInitYVelocity);

            // Recipe = select one Recipe random            
        }

        // TODO: create other ctor for load data from saved game

    }
}
