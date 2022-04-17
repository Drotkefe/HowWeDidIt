using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.Models;
using HowWeDidIt.GameRenderer.Helpers;
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
        Brush backgroundPattern;
        ImageBrush caveManPattern;

        // For testing
        Pen blackPen = new Pen(Brushes.Black, 2);
        Typeface font = new Typeface("Comic Sans");
        Point textStartPoint = new Point(13, 13);
        // up to this point


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

        readonly Lazy<ImageBrush> PotatoBrush;
        readonly Lazy<ImageBrush> DrumStickBrush;
        readonly Lazy<ImageBrush> OnionBrush;
        readonly Lazy<ImageBrush> CarrotBrush;
        readonly Lazy<ImageBrush> EggBrush; 
        readonly Lazy<ImageBrush> UraniumBrush;

        public GameRenderer(IGameModel gameModel, IGameSettings gameSettings)
        {
            this.gameModel = gameModel;
            this.gameSettings = gameSettings;
            backgroundPattern = new ImageBrush(new BitmapImage(new System.Uri(gameSettings.BackgroudPath, System.UriKind.Relative)));
            caveManPattern = new ImageBrush(new BitmapImage(new System.Uri(gameSettings.CaveManPath, System.UriKind.Relative)));

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
                    //{
                    //    Orientations.None, new Dictionary<int, Lazy<ImageBrush>>()
                    //    {
                    //        { 0, StandR },
                    //        { 1, L6 },
                    //    }
                    //},
                };
            PotatoBrush = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.FIPotatoPatternPath));
            DrumStickBrush = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.FIDrumStickPatternPath));
            OnionBrush = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.FIOnionPatternPath));
            CarrotBrush = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.FICarrotPatternPath));
            EggBrush = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.FIEggPatternPath));
            UraniumBrush = new Lazy<ImageBrush>(() => LoadBrush(gameSettings.FIUraniumPatternPath));

        }

        private ImageBrush LoadBrush(string brushPath)
        {
            var brush = new ImageBrush(new BitmapImage(new Uri(brushPath, UriKind.Relative)));
            return brush;
        }

        public void Display(DrawingContext ctx)
        {
            DrawBackground(ctx);
            DrawCaveMan(ctx);
            DrawFoodItems(ctx);
            DrawErrors(ctx);
        }
        // this method is only added for testing
        private void DrawErrors(DrawingContext ctx)
        {
            var text = new FormattedText(
                CollectionInfo(),                
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                font, 13, Brushes.DarkGreen, 1.25);

            ctx.DrawText(text, textStartPoint);
        }

        private string CollectionInfo()
        {
            string info = "";

            info += "Garbage produced: " + gameModel.GarbageCount.ToString() + "\n";

            foreach (var fc in gameModel.FoodCapacities)
            {
                int quantity = 0;
                
                if (gameModel.CollectedFoods.ContainsKey(fc.Key))
                {
                    quantity = gameModel.CollectedFoods[fc.Key];
                }
                info += fc.Key + ": " + fc.Value + "- " +  quantity.ToString() + "\n";
            }
            if (gameModel.CollectedFoods.ToList().All(x => x.Value == gameModel.FoodCapacities[x.Key]))
            {
                gameModel.Recipe.AllFoodItemsCollected = true;

                info += "You are ready to cook.";
            }
           
            return info;
        }

        //private void DrawCaveEntrance(DrawingContext ctx)
        //{
        //    ctx.DrawRectangle(null, new Pen(Brushes.Black, 2), new Rect(87, 295, 55, 55));
        //}

        private void DrawCaveMan(DrawingContext ctx)
        {
            // Az ősember téglalapjának a megrajzolását (pattern) jobb lenne áthelyezni a DisplayExtensionbe
            var halfWidth = 20;
            var halfHeight = 20;
            
            var pattern = new Rect(
                gameModel.CaveMan.X - halfWidth,
                gameModel.CaveMan.Y - halfHeight,
                55,
                55);
     
            switch (gameModel.CaveMan.Orientation)
            {
                case Orientations.Right:
                    caveManPattern = playerBrushStorage[gameModel.CaveMan.Orientation][gameModel.CaveMan.MovementState].Value;
                    break;
                case Orientations.Left:
                    caveManPattern = playerBrushStorage[gameModel.CaveMan.Orientation][gameModel.CaveMan.MovementState].Value;
                    break;

            }
            ctx.DrawRectangle(caveManPattern, null, pattern);
            // akkor ezt a metódust kellene használni hozzá
            // ctx.DrawGeometry(caveManPattern, null, gameModel.CaveMan.GetGeometry(gameSettings: gameSettings));

        }

        private void DrawBackground(DrawingContext ctx)
        {
            ctx.DrawRectangle(backgroundPattern,null,new Rect(0, 0, gameModel.GameAreaWidth, gameModel.GameAreaHeight));
        }

        //    //foods
        private void DrawFoodItems(DrawingContext ctx)
        {
            foreach (var foodItem in gameModel.FoodItems)
            {
                //ctx.DrawRectangle(GetProperFoodItemBrush(foodItem), null, new Rect(foodItem.X, foodItem.Y, 24, 24));
                ctx.DrawGeometry(GetProperFoodItemBrush(foodItem), null, foodItem.GetGeometry());
            }
        }
        private Brush GetProperFoodItemBrush(MovingFoodItem item)
        {
            Brush brush = PotatoBrush.Value;
            switch (item.Name)
            {
                case Foods.Potato:
                    brush = PotatoBrush.Value;
                    break;
                case Foods.Meat:
                    brush = DrumStickBrush.Value;
                    break;
                case Foods.Onion:
                    brush = OnionBrush.Value;
                    break;
                case Foods.Carrot:
                    brush = CarrotBrush.Value;
                    break;
                case Foods.Egg:
                    brush = EggBrush.Value;
                    break;
                case Foods.Uranium:
                    brush = UraniumBrush.Value;
                    break;
            }
            return brush;
        }


      




       
        

       
       
    }
}
