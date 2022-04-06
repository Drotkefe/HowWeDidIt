using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HowWeDidIt.GameRenderer
{
    public interface IGameRenderer
    {
        Drawing GetDrawing();
    }
}
