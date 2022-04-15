using GalaSoft.MvvmLight.Messaging;
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

        public void RestoreHeathPoits(IGameModel gameModel)
        {
            if (true) //  <-------------------gameModel.Recipe.Cooked
            {
                int health = gameModel.Vitality;
                health += gameModel.Recipe.VitalityValue;
                if (health > 100)
                {
                    health = 100;
                }
                gameModel.Vitality = health;

                //TODO: új recept kiválasztása a repositoriból
                //TODO: Pot kinullázása

                messenger.Send("Player healing was successful", "KitchenBlOperationResult");
            }
            else
            {
                messenger.Send("Player healing was not successful", "KitchenBlOperationResult");
            }
        }

        public void SellProduct(IGameModel gameModel)
        {
            if (true) //  <-------------------gameModel.Recipe.Cooked
            {
                gameModel.Money += gameModel.Recipe.MoneyValue;

                //TODO: új recept kiválasztása a repositoriból
                //TODO: Pot kinullázása

                messenger.Send("Product sell was successful", "KitchenBlOperationResult");
            }
            else
            {
                messenger.Send("Product sell was not successful", "KitchenBlOperationResult");
            }
        }
    }
}
