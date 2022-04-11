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
        public List<FoodItem> FoodItems { get; set; } 
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

        public Recipe(string name, List<FoodItem> foodItems, TimeSpan cookingTime, bool cooked, int recipeScore, int vitalityValue, int moneyValue)
        {
            Name = name;
            FoodItems = foodItems;
            CookingTime = cookingTime;
            this.cooked = cooked;
            RecipeScore = recipeScore;
            VitalityValue = vitalityValue;
            MoneyValue = moneyValue;
        }
    }
}
