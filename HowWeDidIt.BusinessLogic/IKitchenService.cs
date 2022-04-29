using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.BusinessLogic
{
    public interface IKitchenService
    {
        void RestoreHeathPoits(IGameModel gameModel);

        void SellProduct(IGameModel gameModel);


        void UpgradeStorage(string typeOfCapacity, IGameModel gameModel);

        void FoodToPot(string typeOfFood, IGameModel gameModel);

        Recipe NewRecipe();
    }
}
