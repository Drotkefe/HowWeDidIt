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
        CaveMan CaveMan { get; }
        Recipe Recipe { get; }


        //List<FoodItem> FoodItems { get; }
        Dictionary<Foods, int> CollectedFoods { get; }
        Dictionary<Foods, int> FoodCapacities { get; }


        int Vitality { get; set; }
        int Money { get; set; }
        int GameScore { get; set; }
        double GameAreaHeight { get; set; }
        double GameAreaWidth { get; set; }      
    }
}
