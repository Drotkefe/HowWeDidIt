using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.GameSettings
{
    public class GameSettings : IGameSettings
    {
        #region CaveMan

        public double CaveManInitXPosition => 300;

        public double CaveManInitYPosition => 450;

        public double CaveManInitXVelocity => 10;

        public double CaveManInitYVelocity => 0;

        #endregion

        // TODO

        public string BackgroudPath => "Images/background.png";

        public string CaveManPath => throw new NotImplementedException();

        public double GameAreaDefaultWidth => 800; // To be set right once it is known

        public double GameAreaDefaultHeight => 450; // // To be set right once it is known
    }
}
