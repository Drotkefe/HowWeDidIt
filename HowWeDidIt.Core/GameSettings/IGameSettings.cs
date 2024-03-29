﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.GameSettings
{
    public interface IGameSettings
    {
        #region CaveMan

        public double CaveManInitXPosition { get; }

        public double CaveManInitYPosition { get; }

        public double CaveManInitXVelocity { get; }

        public double CaveManInitYVelocity { get; }
        #endregion

        #region General

        string BackgroudPath { get; }

        string CaveManPath { get; }        

        double GameAreaDefaultWidth { get; }

        double GameAreaDefaultHeight { get; }


        #endregion

        #region Rendering
        public string CaveMan1L { get;}
        public string CaveMan1R { get; }
        public string CaveMan2L { get; }
        public string CaveMan2R { get;  }
        public string CaveMan3L { get;}
        public string CaveMan3R { get; }
        public string CaveMan4L { get; }
        public string CaveMan4R { get;  }
        public string CaveMan5L { get;  }
        public string CaveMan5R { get;  }
        public string CaveMan6L { get;  }
        public string CaveMan6R { get; }

        public string FIPotatoPatternPath { get; }
        public string FIDrumStickPatternPath { get; }
        public string FIOnionPatternPath { get; }
        public string FICarrotPatternPath { get; }
        public string FIEggPatternPath { get; }
        public string FIUraniumPatternPath { get; }

        public string KompostPath { get; }
        #endregion

        int MaximalAllowedMovementState { get; set; }

        #region MovingFoodItem

        public int FoodItemCount { get; }

        public double FoodItemYVelocity { get; }
       
        #endregion
    }
}
