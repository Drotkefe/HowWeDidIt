using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Core.GameSettings
{
    public interface IGameSettings
    {
        #region CaveMan

        double CaveManInitXPosition { get; }

        double CaveManInitYPosition { get; }

        double CaveManInitXVelocity { get; }

        double CaveManInitYVelocity { get; }
        #endregion

        #region General

        string BackgroudPath { get; }

        string CaveManPath { get; }        

        double GameAreaDefaultWidth { get; }

        double GameAreaDefaultHeight { get; }

        #endregion
    }
}
