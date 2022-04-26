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
        GameModel GetGameModel();
        void StoreGameModel(IGameModel gameModel);
    }
}
