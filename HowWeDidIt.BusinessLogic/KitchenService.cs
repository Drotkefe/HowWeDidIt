using GalaSoft.MvvmLight.Messaging;
using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;

namespace HowWeDidIt.BusinessLogic
{
    public class KitchenService : IKitchenService
    {
        readonly IMessenger messenger;
        RandomGenerator generator = new RandomGenerator();

        public KitchenService(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void FoodToPot(string typeOfFood, IGameModel gameModel)
        {
            Foods caughtFood = (Foods)Enum.Parse(typeof(Foods), typeOfFood);

            if (gameModel.GarbageCount >= gameModel.GarbageCapacity) messenger.Send("Hygenie Alert! Empty the trash.", "KitchenBlOperationResult");
            else if (gameModel.CollectedFoods[caughtFood] > 0)
            {
                if (!gameModel.Recipe.Cooked)
                {
                    CookFood(caughtFood, gameModel);
                }
                else messenger.Send("The dish is complete. Sell or heal!", "KitchenBlOperationResult");
            }
            else messenger.Send("There is not enough food like this.", "KitchenBlOperationResult");
        }

        public void CookFood(Foods caughtFood, IGameModel gameModel)
        {
            if (caughtFood.Equals(Foods.Meat)) gameModel.GarbageCount += 3;
            else if (caughtFood.Equals(Foods.Egg)) gameModel.GarbageCount += 2;
            else if (!caughtFood.Equals(Foods.Uranium)) gameModel.GarbageCount += 1; // if NOT uranium
            if (gameModel.GarbageCount > gameModel.GarbageCapacity) gameModel.GarbageCount = gameModel.GarbageCapacity;

            gameModel.CollectedFoods[caughtFood]--;

            if (gameModel.Recipe.FoodList[gameModel.Recipe.CurrentFoodIndex] == caughtFood)  // if right food
            {
                if (gameModel.Recipe.CurrentFoodIndex < gameModel.Recipe.FoodList.Count - 1)
                {
                    gameModel.Recipe.CurrentFoodIndex++;
                    messenger.Send("Food added to pot!", "KitchenBlOperationResult");
                }
                else
                {
                    gameModel.Recipe.Cooked = true;
                    gameModel.GameScore += gameModel.Recipe.RecipeScore;
                    messenger.Send("The dish is complete. Sell or heal!", "KitchenBlOperationResult");
                }
            }
            else
            {
                messenger.Send("Wrong item cauthed", "KitchenBlOperationResult");

                if (caughtFood.Equals(Foods.Meat)) gameModel.GarbageCount += 4;
                else if (caughtFood.Equals(Foods.Egg)) gameModel.GarbageCount += 3;
                else gameModel.GarbageCount += 2;
                if (gameModel.GarbageCount > gameModel.GarbageCapacity) gameModel.GarbageCount = gameModel.GarbageCapacity;
            }

            if (gameModel.GarbageCount >= gameModel.GarbageCapacity) messenger.Send("Hygenie Alert! Empty the trash.", "KitchenBlOperationResult");
        }

        public Recipe NewRecipe()
        {

            Recipe recipe = new Recipe();
            string[] names = new string[] { "Pizza", "HotDog", "Hamburger", "Gyros", "Something" };
            recipe.Name = names[generator.Random.Next(names.Length)];

            List<Foods> foods = new List<Foods>();
            int cathegory = generator.Random.Next(10);

            if (cathegory < 5)
            {
                recipe.VitalityValue = 60;
                recipe.MoneyValue = 100;

                for (int i = 0; i < generator.Random.Next(5, 7); i++)
                {
                    foods.Add((Foods)generator.Random.Next(6));
                }
                ;
            }
            else if (cathegory < 8)
            {
                recipe.VitalityValue = 80;
                recipe.MoneyValue = 150;
                for (int i = 0; i < generator.Random.Next(7, 9); i++)
                {
                    foods.Add((Foods)generator.Random.Next(6));   // not working: sizeof(Foods)) it give 4 instead of 6
                }
            }
            else
            {
                recipe.VitalityValue = 100;
                recipe.MoneyValue = 200;
                for (int i = 0; i < generator.Random.Next(9, 11); i++)
                {
                    foods.Add((Foods)generator.Random.Next(sizeof(Foods)));
                }
            }

            foreach (var f in foods)
            {
                recipe.FoodList.Add(f);
            }

            recipe.RecipeScore = foods.Count * 5;
            recipe.CurrentFoodIndex = 0;
            recipe.Cooked = false;

            return recipe;
        }

        public void RestoreHeathPoits(IGameModel gameModel)
        {
            if (gameModel.Recipe.Cooked)
            {
                int health = gameModel.Vitality;
                health += gameModel.Recipe.VitalityValue;
                if (health > 100)
                {
                    health = 100;
                }
                gameModel.Vitality = health;

                gameModel.Recipe = NewRecipe();
                messenger.Send("Player healing was successful", "KitchenBlOperationResult");
            }
            else messenger.Send("Player healing was not successful", "KitchenBlOperationResult");
        }

        public void SellProduct(IGameModel gameModel)
        {
            if (gameModel.Recipe.Cooked)
            {
                gameModel.Money += gameModel.Recipe.MoneyValue;
                gameModel.Recipe = NewRecipe();
                messenger.Send("Product sell was successful", "KitchenBlOperationResult");
            }
            else messenger.Send("Product sell was not successful", "KitchenBlOperationResult");
        }


        public void UpgradeStorage(string typeOfCapacity, IGameModel gameModel) //DONE
        {
            if (gameModel.Money >= 100)
            {
                if (typeOfCapacity.Equals("Garbage"))
                {
                    gameModel.GarbageCapacity += 2;
                    gameModel.Money -= 100;
                }
                else
                {
                    Foods foodStorage = (Foods)Enum.Parse(typeof(Foods), typeOfCapacity);

                    gameModel.FoodCapacities[foodStorage] += 2;
                    gameModel.Money -= 100;
                }
                messenger.Send("Upgrade was successful", "KitchenBlOperationResult");
            }
            else messenger.Send("Upgrade was not successful", "KitchenBlOperationResult");
        }
    }
}
