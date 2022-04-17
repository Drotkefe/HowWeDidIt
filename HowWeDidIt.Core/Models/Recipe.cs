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

        // Ezt a tulajdonságot a konstruktor beállítja false-ra. Amikor a Renderer nézi a CollectionInfo-ban, hogy megvan-e minden hozzávaló, amikor, igen, igazra változtatja, és az kiválathat egy eseményt a képernyőváltozáshoz

        private bool allFoodItemsCollected;

        public bool AllFoodItemsCollected
        {
            get { return allFoodItemsCollected; }
            set { allFoodItemsCollected = value; }
        }


        private bool cooked;
        public bool Cooked
        {
            get { return cooked; }
            set { cooked = value; }
        }

        public int RecipeScore { get; set; }        
        public int VitalityValue { get; set; }
        public int MoneyValue { get; set; }

        public Recipe()
        {
                
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
            AllFoodItemsCollected = false;
        }
    }
}
