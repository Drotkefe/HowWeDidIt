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

        public int CookingTime { get; set; }
        private bool cooked;



        public bool Cooked
        {
            get { return cooked; }
            set { cooked = value; }
        }

        public int RecipeScore { get; set; }        
        public int VitalityValue { get; set; }
        public int MoneyValue { get; set; }




    }
}
