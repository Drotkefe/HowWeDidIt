using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Foods> FoodItems { get; set; } 
        public TimeSpan CookingTime { get; set; }
                
        private bool cooked;
        public bool Cooked
        {
            get { return cooked; }
            set { cooked = value; }
        }

        public int RecipeScore { get; set; }        
        public int VitalityValue { get; set; }
        public int MoneyValue { get; set; }


        private int currentFoodIndex;
        public int CurrentFoodIndex
        {
            get { return currentFoodIndex; }
            set { currentFoodIndex = value; }
        }



        public Recipe(string name, List<Foods> foodItems, TimeSpan cookingTime, bool cooked, int recipeScore, int vitalityValue, int moneyValue)
        {
            Name = name;
            FoodItems = foodItems;
            CookingTime = cookingTime;
            this.cooked = cooked;
            RecipeScore = recipeScore;
            VitalityValue = vitalityValue;
            MoneyValue = moneyValue;


            this.currentFoodIndex = currentFoodIndex;
        }
    }
}
