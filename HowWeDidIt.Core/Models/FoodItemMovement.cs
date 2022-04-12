using HowWeDidIt.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Models
{
    public class FoodItemMovement : GameItemMovement
    {
        public Foods Name { get; set; }

        /// <summary>
        /// Represents x axis of speed.
        /// </summary>
        public double DX { get; set; }

        /// <summary>
        /// Represents y axis based signed displacement.
        /// </summary>
        public double DY { get; set; }

        /// <summary>
        /// Gets the coordinates of its position and its speed vector
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dX"></param>
        /// <param name="dY"></param>
        public FoodItemMovement(double x, double y, double dX, double dY) : base(x, y)
        {
            DX = dX;
            DY = dY; // in our case DY = 0;
        }
    }
}
