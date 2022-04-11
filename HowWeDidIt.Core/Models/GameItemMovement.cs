using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Models
{
    public abstract class GameItemMovement
    {
        /// <summary>
        /// Defines object x position.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Defines object y position.
        /// </summary>
        public double Y { get; set; }

        public double Angle { get; private set; }

        public double AngleInRad
        {
            get { return Angle * Math.PI / 180; }
            set { Angle = value * 180 / Math.PI; }
        }

        protected GameItemMovement(double x, double y)
        {
            X = x;
            Y = y;
            Angle = 0;
        }
    }
}
