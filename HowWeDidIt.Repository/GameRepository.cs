using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.GameSettings;
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
        readonly IGameSettings gameSettings;

        public GameRepository(IGameSettings gameSettings)
        {
           
            this.gameSettings = gameSettings;
        }
        public MovingCaveMan GetCaveManByName(string caveManName = null)
        {
            var fileName = $"{caveManName}\\{caveManName}"; 

            if (String.IsNullOrEmpty(caveManName))
            {
                fileName = $"{gameSettings.CaveManName}\\{gameSettings.CaveManFileName}";
                caveManName = gameSettings.CaveManName;
            }
            else if (!fileName.EndsWith(gameSettings.CaveManFileNameExtension))
            {
                fileName += gameSettings.CaveManFileNameExtension; 
            }

            MovingCaveMan caveMan;

            if (File.Exists(fileName))
            {
                var sr = new StreamReader(fileName);

                //File structure
                //400; 321; 14; 0 pozíció és sebesség
                //LenniŐsember - neve
                //0 movement state
                //0 orientation -- ezek kellenek a konstruktorba
               

                var cont = sr.ReadLine().Split(gameSettings.CaveManFileDelimiter);
                var name = sr.ReadLine();
                var orientation = sr.ReadLine();
                var movementState = sr.ReadLine();

                caveMan = new MovingCaveMan(
                    double.Parse(cont[0]),
                    double.Parse(cont[1]),
                    double.Parse(cont[2]),
                    double.Parse(cont[3]),
                    name,
                    int.Parse(movementState),
                    (Orientations)Enum.Parse(typeof(Orientations), orientation)
                    );                
            }
            else
            {
                caveMan = new MovingCaveMan(gameSettings.CaveManInitXPosition, gameSettings.CaveManInitYPosition, gameSettings.CaveManInitXVelocity, gameSettings.CaveManInitYVelocity);
            }

            return caveMan;
        }

        public void StoreCaveMan(MovingCaveMan caveMan)
        {
            if (!Directory.Exists(caveMan.Name))
            {
                Directory.CreateDirectory(caveMan.Name);
            }

            var sw = new StreamWriter($"{caveMan.Name}\\{caveMan.Name}{gameSettings.CaveManFileNameExtension}");

            var sb = new StringBuilder();

            sb.AppendFormat("{0}{1}{2}{3}{4}{5}\n", caveMan.X, gameSettings.CaveManFileDelimiter, caveMan.Y, gameSettings.CaveManFileDelimiter, caveMan.DX, gameSettings.CaveManFileDelimiter, caveMan.DY);
            sb.AppendLine(caveMan.Name);
            sb.AppendLine(caveMan.MovementState.ToString());
            sb.AppendLine(caveMan.Orientation.ToString());           

            sw.WriteLine(sb.ToString());

            sw.Close();
        }
    }
}
