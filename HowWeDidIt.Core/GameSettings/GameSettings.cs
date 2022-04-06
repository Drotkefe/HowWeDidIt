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

        #region rendering
        public string BackgroudPath => "Images\\background.png";

        public string CaveManPath => "Images\\StandR.png";
        public string CaveMan1L => "Images\\1L.png";
        public string CaveMan1R => "Images\\1R.png";
        public string CaveMan2L => "Images\\2L.png";
        public string CaveMan2R => "Images\\2R.png";
        public string CaveMan3L => "Images\\3L.png";
        public string CaveMan3R => "Images\\3R.png";
        public string CaveMan4L => "Images\\4L.png";
        public string CaveMan4R => "Images\\4R.png";
        public string CaveMan5L => "Images\\5L.png";
        public string CaveMan5R => "Images\\5R.png";
        public string CaveMan6L => "Images\\6L.png";
        public string CaveMan6R => "Images\\6R.png";
       
        

        #endregion



        public double GameAreaDefaultWidth => 800; // To be set right once it is known

        public double GameAreaDefaultHeight => 450; // // To be set right once it is known

        public int MaximalAllowedMovementState { get; set; } = 6;
    }
}
