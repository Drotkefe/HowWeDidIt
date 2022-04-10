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
        public string[,] FoodItems { get; set; }        // ezt hogy értitek? string mátrix? -> FoodItems Lista?
        //public string[,] Crate { get; set; }            // ez miért itt van a receptben? + string mátrix
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
