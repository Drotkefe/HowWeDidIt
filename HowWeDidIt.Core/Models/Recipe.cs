using HowWeDidIt.Core.Enums;
using System;
using System.Collections.Generic;

namespace HowWeDidIt.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Foods> FoodList { get; set; }


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

    }
}
