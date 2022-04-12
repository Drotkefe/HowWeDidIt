using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.Models
{
    public interface IKitchenModel
    {
        double GameAreaHeight { get; set; }
        double GameAreaWidth { get; set; }


        Recipe Recipe { get; set; }

        Dictionary<Foods, int> CollectedFoods { get; set; }
        Dictionary<Foods, int> FoodCapacities { get; set; }
        

        int GarbageCount { get; set; }
        int GarbageCapacity { get; set; }
        

        int Vitality { get; set; } // (maximum is 10)
        int Money { get; set; }
        int GameScore { get; set; }
    }
}
