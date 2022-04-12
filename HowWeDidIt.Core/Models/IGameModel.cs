using HowWeDidIt.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Models
{
    public interface IGameModel
    {

        double GameAreaHeight { get; set; }
        double GameAreaWidth { get; set; }


        MovingCaveMan CaveMan { get; }


        Recipe Recipe { get; }
        Dictionary<Foods, int> CollectedFoods { get; }
        Dictionary<Foods, int> FoodCapacities { get; }
        int GarbageCount { get; set; }
        int GarbageCapacity { get; set; }
        int Vitality { get; set; }
        int Money { get; set; }
        int GameScore { get; set; }


    }
}
