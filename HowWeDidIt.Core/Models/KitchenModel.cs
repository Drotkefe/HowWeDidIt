using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.Models
{
    public class KitchenModel : IKitchenModel
    {
        public Recipe Recipe { get; set; }
        public Dictionary<Foods, int> CollectedFoods { get; set; }
        public Dictionary<Foods, int> FoodCapacities { get; set; }
        public int GarbageCount { get; set; }
        public int GarbageCapacity { get; set; }
        public int Vitality { get; set; }
        public int Money { get; set; }
        public int GameScore { get; set; }


        public KitchenModel()
        {

        }

        public KitchenModel(Recipe recipe, Dictionary<Foods, int> collectedFoods, Dictionary<Foods, int> foodCapacities, int garbageCount, int garbageCapacity, int vitality, int money, int gameScore)
        {
            Recipe = recipe;
            CollectedFoods = collectedFoods;
            FoodCapacities = foodCapacities;
            GarbageCount = garbageCount;
            GarbageCapacity = garbageCapacity;
            Vitality = vitality;
            Money = money;
            GameScore = gameScore;
        }
    }
}
