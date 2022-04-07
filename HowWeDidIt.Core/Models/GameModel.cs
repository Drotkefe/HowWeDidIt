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
        public CaveMan CaveMan { get; private set; }
        public Recipe Recipe { get; private set; }
        public List<FoodItem> FoodItems { get; private set; }

        public int Vitality { get; set; }
        public int Money { get; set; }
        public int GameScore { get; set; }

        public double GameAreaHeight { get; set; }
        public double GameAreaWidth { get; set; }        

        public GameModel(double gameAreaWidth, double gameAreaHeight, IGameSettings gameSettings)
        {
            GameAreaWidth = gameAreaWidth;
            GameAreaHeight = gameAreaHeight;
            FoodItems = new List<FoodItem>();

            InitDefaultValues(gameSettings, gameAreaWidth, gameAreaHeight);
        }

        private void InitDefaultValues(IGameSettings gameSettings, double gameAreaWidth, double gameAreaHeight)
        {
            CaveMan = new CaveMan(gameSettings.CaveManInitXPosition, gameSettings.CaveManInitYPosition, gameSettings.CaveManInitXVelocity, gameSettings.CaveManInitYVelocity);

            // Recipe = select one Recipe random            
        }

        // TODO: create other ctor for load data from saved game

    }
}
