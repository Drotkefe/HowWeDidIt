using HowWeDidIt.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.Models
{
    public class FoodItem
    {
        public Foods Name { get; }
        public int CookingByProduct { get; }
        public int Garbage { get; }

        public FoodItem(Foods name, int cookingByProduct, int garbage)
        {
            Name = name;
            CookingByProduct = cookingByProduct;
            Garbage = garbage;
        }
    }

}
