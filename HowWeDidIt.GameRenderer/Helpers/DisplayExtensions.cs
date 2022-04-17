using HowWeDidIt.Core;
using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HowWeDidIt.GameRenderer.Helpers
{
    public static class DisplayExtensions
    {
        public static Geometry GetGeometry(this MovingGameItem item, IGameSettings gameSettings = null)
        {
            var tg = new TransformGroup();
            tg.Children.Add(new TranslateTransform(item.X, item.Y));

            Geometry geometry;

            if (item is MovingCaveMan)
            {
               geometry = CaveManGeometry(gameSettings); 
            }
            else
            {
                geometry = FoodItemGeometry();
            }

            geometry.Transform = tg;
            return geometry.GetFlattenedPathGeometry();
        }
        static Geometry CaveManGeometry(IGameSettings gameSettings)
        { 
            return new RectangleGeometry(new System.Windows.Rect(0, 0, 55, 55));
        }
        static Geometry FoodItemGeometry()
        {
            return new RectangleGeometry(new System.Windows.Rect(0, 0, 24, 24)); // the same as in DrawFoodItems in Renderer
        }

    }
    
}
