using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.BusinessLogic
{
    public interface IGameLogic
    {
        IGameModel GameModel { get; }
        event EventHandler CallRefresh;

        void Move(double dx, double dy);
        //void Save(); későbbre
    }
}
