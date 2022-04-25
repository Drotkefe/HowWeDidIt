using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Repository
{
    public class GameRepository : IGameRepository
    {
        public IGameModel GameModel { get; private set; }
        public GameModel GetGameModel()
        {
            throw new NotImplementedException();
        }

        public void StoreGameModel()
        {
            List<string> output = new List<string>();
            output.Add(GameModel.Vitality.ToString());
            output.Add(GameModel.Money.ToString());
            output.Add(GameModel.GameScore.ToString());
            output.Add(GameModel.Recipe.Name);
            //foreach (var item in GameModel.Recipe.)
            //{

            //}

        }
    }
}
