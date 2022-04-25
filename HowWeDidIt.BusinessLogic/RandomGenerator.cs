using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.BusinessLogic
{
    public class RandomGenerator
    {
        public Random Random { get; set; }

        public RandomGenerator()
        {
            Random = new Random();
        }
    }
}
