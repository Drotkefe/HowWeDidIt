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
        public int CookingByProduct { get; set; }
        public int Garbage { get; set; }

        
    }

}
