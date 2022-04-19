using GalaSoft.MvvmLight.Messaging;
using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.BusinessLogic
{
    public class KitchenService : IKitchenService
    {
        readonly IMessenger messenger;

        public KitchenService(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void FoodToPot(string typeOfFood, IGameModel gameModel)
        {
            ; //TODO: write game logic

            Foods caughtFood = (Foods)Enum.Parse(typeof(Foods), typeOfFood);


            if (gameModel.CollectedFoods[caughtFood] > 0)
            {
                if (gameModel.Recipe.FoodList[gameModel.Recipe.CurrentFoodIndex] == caughtFood)
                {
                    gameModel.CollectedFoods[caughtFood]--;
                    gameModel.Recipe.CurrentFoodIndex++;

                }
                else
                {

                }

            }

        }

        public void RestoreHeathPoits(IGameModel gameModel)
        {
            if (gameModel.Recipe.Cooked) //  <-------------------gameModel.Recipe.Cooked
            {
                int health = gameModel.Vitality;
                health += gameModel.Recipe.VitalityValue;
                if (health > 100)
                {
                    health = 100;
                }
                gameModel.Vitality = health;

                //TODO: új recept kiválasztása a repositoriból


                messenger.Send("Player healing was successful", "KitchenBlOperationResult");
            }
            else
            {
                messenger.Send("Player healing was not successful", "KitchenBlOperationResult");
            }
        }

        public void SellProduct(IGameModel gameModel)
        {
            if (gameModel.Recipe.Cooked) //  <-------------------gameModel.Recipe.Cooked
            {
                gameModel.Money += gameModel.Recipe.MoneyValue;

                //TODO: új recept kiválasztása a repositoriból


                messenger.Send("Product sell was successful", "KitchenBlOperationResult");
            }
            else
            {
                messenger.Send("Product sell was not successful", "KitchenBlOperationResult");
            }
        }


        public void UpgradeStorage(string typeOfCapacity, IGameModel gameModel) //DONE
        {
            if (gameModel.Money >= 200)
            {
                if (typeOfCapacity.Equals("Garbage"))
                {
                    gameModel.GarbageCapacity += 2;
                    gameModel.Money -= 200;
                }
                else
                {
                    Foods foodStorage = (Foods)Enum.Parse(typeof(Foods), typeOfCapacity);

                    gameModel.FoodCapacities[foodStorage] += 2;
                    gameModel.Money -= 200;
                }

                messenger.Send("Upgrade was successful", "KitchenBlOperationResult");
            }
            else
            {
                messenger.Send("Upgrade was not successful", "KitchenBlOperationResult");
            }
        }
    }
}
