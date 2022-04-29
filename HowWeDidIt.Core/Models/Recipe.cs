using HowWeDidIt.Core.Enums;
using System;
using System.Collections.Generic;

namespace HowWeDidIt.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Foods> FoodList { get; set; }
        public TimeSpan CookingTime { get; set; }



        public int RecipeScore { get; set; }
        public int VitalityValue { get; set; }
        public int MoneyValue { get; set; }



        private bool cooked;
        public bool Cooked
        {
            get { return cooked; }
            set { cooked = value; }
        }


        private int currentFoodIndex;
        public int CurrentFoodIndex
        {
            get { return currentFoodIndex; }
            set { currentFoodIndex = value; }
        }

        public Recipe()
        {
            FoodList = new List<Foods>();
        }

        //public Recipe(string name, List<Foods> foodItems, TimeSpan cookingTime, int recipeScore, int vitalityValue, int moneyValue, int currentFoodIndex = 0, bool cooked = false)
        //{
        //    Name = name;
        //    FoodList = foodItems;
        //    CookingTime = cookingTime;
        //    RecipeScore = recipeScore;
        //    VitalityValue = vitalityValue;
        //    MoneyValue = moneyValue;
        //    this.cooked = cooked;
        //    this.currentFoodIndex = currentFoodIndex;
        //}
    }
}
