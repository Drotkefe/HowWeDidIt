﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.GameSettings
{
    public class GameSettings : IGameSettings
    {
        #region CaveMan

        public double CaveManInitXPosition => 400;

        public double CaveManInitYPosition => 321;

        public double CaveManInitXVelocity => 14;

        public double CaveManInitYVelocity => 0;

        #endregion

        // TODO

        #region rendering
        public string BackgroudPath => @"Images\background.png";

        public string CaveManPath => @"Images\StandR.png";
        public string CaveMan1L => @"Images\mozgas\1L.png";
        public string CaveMan1R => @"Images\mozgas\1R.png";
        public string CaveMan2L => @"Images\mozgas\2L.png";
        public string CaveMan2R => @"Images\mozgas\2R.png";
        public string CaveMan3L => @"Images\mozgas\3L.png";
        public string CaveMan3R => @"Images\mozgas\3R.png";
        public string CaveMan4L => @"Images\mozgas\4L.png";
        public string CaveMan4R => @"Images\mozgas\4R.png";
        public string CaveMan5L => @"Images\mozgas\5L.png";
        public string CaveMan5R => @"Images\mozgas\5R.png";
        public string CaveMan6L => @"Images\mozgas\6L.png";
        public string CaveMan6R => @"Images\mozgas\6R.png";



        #endregion

        #region MovingFoodItem

        public int FoodItemCount => 3;

        public double FoodItemYVelocity => 14;        

        #endregion

        public double GameAreaDefaultWidth => 800; // To be set right once it is known

        public double GameAreaDefaultHeight => 450; // // To be set right once it is known

        public int MaximalAllowedMovementState { get; set; } = 6;        
    }
}
