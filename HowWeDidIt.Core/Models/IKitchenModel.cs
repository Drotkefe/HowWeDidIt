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
        Recipe Recipe { get; set; }

        Dictionary<FoodItem, int> CollectedFoods { get; set; }

        int GarbageCount { get; set; }
        int GarbageCapacity { get; set; }
        

        int Vitality { get; set; } // (maximum is 10)
        int Money { get; set; }
        int GameScore { get; set; }
    }
}
