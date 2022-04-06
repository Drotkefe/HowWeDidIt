using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HowWeDidIt.GameRenderer
{
    public class GameRenderer : IGameRenderer
    {
        readonly IGameModel gameModel;
        readonly IGameSettings gameSettings;

        readonly Lazy<ImageBrush> playerBrush;
        readonly Lazy<ImageBrush> StandR;
        readonly Lazy<ImageBrush> R1;
        readonly Lazy<ImageBrush> R2;
        readonly Lazy<ImageBrush> R3;
        readonly Lazy<ImageBrush> R4;
        readonly Lazy<ImageBrush> R5;
        readonly Lazy<ImageBrush> R6;
        readonly Lazy<ImageBrush> L1;
        readonly Lazy<ImageBrush> L2;
        readonly Lazy<ImageBrush> L3;
        readonly Lazy<ImageBrush> L4;
        readonly Lazy<ImageBrush> L5;
        readonly Lazy<ImageBrush> L6;

        readonly Dictionary<Orientations, Dictionary<int, Lazy<ImageBrush>>> playerBrushStorage;

        //foods

        public GameRenderer(IGameModel gameModel, IGameSettings gameSettings)
        {
            this.gameModel = gameModel;
            this.gameSettings = gameSettings;

            playerBrush = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveManPath));
            StandR = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveManPath));
            R1 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan1R));
            R2 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan2R));
            R3 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan3R));
            R4 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan4R));
            R5 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan5R));
            R6 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan6R));
            L1 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan1L));
            L2 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan2L));
            L3 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan3L));
            L4 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan4L));
            L5 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan5L));
            L6 = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.CaveMan6L));
           

            playerBrushStorage = new Dictionary<Orientations, Dictionary<int, Lazy<ImageBrush>>>()
            {
                {
                    Orientations.Right, new Dictionary<int, Lazy<ImageBrush>>()
                    {
                        { 0, R1 },
                        { 1, R2 },
                        { 2, R3 },
                        { 3, R4 },
                        { 4, R5 },
                        { 5, R6 }
                    }
                },
                {
                    Orientations.Left, new Dictionary<int, Lazy<ImageBrush>>()
                    {
                        { 0, L1 },
                        { 1, L2 },
                        { 2, L3 },
                        { 3, L4 },
                        { 4, L5 },
                        { 5, L6 }
                    }
                },
            };
        }

        private ImageBrush LoadBrush(string brushPath)
        {
            var brush = new ImageBrush(new BitmapImage(new Uri(brushPath, UriKind.Relative)));

            brush.TileMode = TileMode.Tile;
            brush.Viewport = new Rect(0, 0, 100, 100); // When viewport is unset, should put to center once in case of individual sizes
            brush.ViewportUnits = BrushMappingMode.Absolute;

            return brush;
        }

        public Drawing GetDrawing()
        {
            var dg = new DrawingGroup();
            //dg.Children.Add(DrawPlayer());

            return dg;
        }

        //private Drawing DrawPlayer()
        //{
        //    var playerGeometry = new RectangleGeometry(new Rect(gameModel.CaveMan.X=400, gameModel.CaveMan.Y=300, 100, 100));

        //    return new GeometryDrawing(GetProperPlayerBrush(), null, playerGeometry);
        //}

        private Brush GetProperPlayerBrush()
        {
            var result = playerBrush.Value;
            switch (gameModel.CaveMan.Orientation)
            {
                case Orientations.Right:
                    result= playerBrushStorage[gameModel.CaveMan.Orientation][gameModel.CaveMan.MovementState].Value;
                    break;
                case Orientations.Left:
                    result = playerBrushStorage[gameModel.CaveMan.Orientation][gameModel.CaveMan.MovementState].Value;
                    break;

            }
            result = StandR.Value;
            return result;
        }
    }
}
