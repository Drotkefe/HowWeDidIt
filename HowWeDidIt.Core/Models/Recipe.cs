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


        public int RecipeScore { get; set; }        
        public int VitalityValue { get; set; }
        public int MoneyValue { get; set; }




        public int currentFoodIndex;
        public int CurrentFoodIndex
        {
            get { return currentFoodIndex; }
            set { currentFoodIndex = value; }
        }


        private bool cooked;
        public bool Cooked
        {
            get { return cooked; }
            set { cooked = value; }
        }
        public Recipe()
        {
                
        }
        public Recipe(string name, List<Foods> foodItems, TimeSpan cookingTime, int recipeScore, int vitalityValue, int moneyValue, int currentFoodIndex = 0, bool cooked = false)
        {
            Name = name;
            FoodItems = foodItems;
            CookingTime = cookingTime;
            RecipeScore = recipeScore;
            VitalityValue = vitalityValue;
            MoneyValue = moneyValue;
            this.cooked = cooked;
        }
    }
}
