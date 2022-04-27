using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Repository
{
    public class GameRepository : IGameRepository
    {
        readonly IGameSettings gameSettings;

        double Width { get; set; }
        double Height { get; set; }

        public GameRepository(double width,double height,IGameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            Width = width;
            Height = height;
        }

        public GameRepository()
        {

        }

        public GameModel GetGameModel()
        {
            Random rnd = new Random();
            GameModel gameModel = new GameModel(Width,Height);
            gameModel.CaveMan = new MovingCaveMan(gameSettings.CaveManInitXPosition, gameSettings.CaveManInitYPosition, gameSettings.CaveManInitXVelocity, gameSettings.CaveManInitYVelocity);
            gameModel.Recipe = new Recipe();
            List<string> lines = File.ReadAllLines("save.txt").ToList();
            if (lines.Count == 1)
            {
                return null;
            }

            gameModel.Vitality = int.Parse(lines[0]);
            gameModel.Money = int.Parse(lines[1]);
            gameModel.GameScore = int.Parse(lines[2]);
            gameModel.Recipe.Name = lines[3];
            int i = 4;
            gameModel.Recipe.FoodList = new List<Foods>();
            while (lines[i] != "-")
            {
                gameModel.Recipe.FoodList.Add((Foods)Enum.Parse(typeof(Foods),lines[i]));
                i++;
            }
            i++;
            gameModel.Recipe.RecipeScore = int.Parse(lines[i]);
            gameModel.Recipe.MoneyValue = int.Parse(lines[i+1]);
            gameModel.Recipe.VitalityValue = int.Parse(lines[i+2]);
            gameModel.Recipe.CurrentFoodIndex = int.Parse(lines[i+3]);
            int j = i + 4;
            gameModel.CollectedFoods = new Dictionary<Foods, int>();
            while (lines[j] != "-")
            {
                string[] entries = lines[j].Split(';');
                gameModel.CollectedFoods.Add((Foods)Enum.Parse(typeof(Foods), entries[0]), int.Parse(entries[1]));
                j++;
            }
            j++;
            gameModel.FoodCapacities = new Dictionary<Foods, int>();
            while (lines[j] != "-")
            {
                string[] entries = lines[j].Split(';');
                gameModel.FoodCapacities.Add((Foods)Enum.Parse(typeof(Foods), entries[0]), int.Parse(entries[1]));
                j++;
            }
            j++;
            gameModel.GarbageCount = int.Parse(lines[j]);
            gameModel.GarbageCapacity = int.Parse(lines[j + 1]);

            gameModel.FoodItems = new List<MovingFoodItem>();
            for (int z = 0; z < gameSettings.FoodItemCount; z++)
            {
                gameModel.FoodItems.Add(new MovingFoodItem((Foods)rnd.Next(0, 6), rnd.Next(gameModel.CollectionAreaBeginning, gameModel.CollectionAreaEnd), 0, 0, gameSettings.FoodItemYVelocity));
            }



            return gameModel;

        }

        public void Reset_Save()
        {
            File.WriteAllText("save.txt", "nothing");
        }

        public void StoreGameModel(IGameModel gameModel)
        {
            List<string> output = new List<string>();
            output.Add(gameModel.Vitality.ToString());
            output.Add(gameModel.Money.ToString());
            output.Add(gameModel.GameScore.ToString());
            output.Add(gameModel.Recipe.Name);
            foreach (var item in gameModel.Recipe.FoodList)
            {
                output.Add($"{item}");
            }
            output.Add("-");
            output.Add($"{gameModel.Recipe.RecipeScore}");
            output.Add($"{gameModel.Recipe.MoneyValue}");
            output.Add($"{gameModel.Recipe.VitalityValue}");
            output.Add($"{gameModel.Recipe.CurrentFoodIndex}");
            foreach (var item in gameModel.CollectedFoods)
            {
                output.Add($"{item.Key};{item.Value}");
               
            }
            output.Add("-");
            foreach (var item in gameModel.FoodCapacities)
            {
                output.Add($"{item.Key};{item.Value}");
                
            }
            output.Add("-");
            output.Add(gameModel.GarbageCount.ToString());
            output.Add(gameModel.GarbageCapacity.ToString());



            File.WriteAllLines("save.txt", output);
           
        }
    }
}
