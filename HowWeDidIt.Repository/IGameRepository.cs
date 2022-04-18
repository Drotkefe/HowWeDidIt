using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Repository
{
    public interface IGameRepository
    {
        MovingCaveMan GetCaveManByName(string caveManName = null);
        void StoreCaveMan(MovingCaveMan caveMan);
    }
}
