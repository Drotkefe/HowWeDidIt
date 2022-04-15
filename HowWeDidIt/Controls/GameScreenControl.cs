using HowWeDidIt.BusinessLogic;
using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.GameRenderer;
using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace HowWeDidIt.Controls
{
    public class GameScreenControl : FrameworkElement
    {
        IGameSettings gameSettings;
        //IGameRepository gameRepository;
        IGameModel gameModel;
        IGameLogic gameLogic;
        IGameRenderer gameRenderer;
        DispatcherTimer timer;

        public GameScreenControl()
        {
            Loaded += HowWeDidIt_Controller_Loaded;
            
        }

        private void HowWeDidIt_Controller_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            InvalidateVisual();

            if (window != null) // Window loaded
            {
                gameSettings = new GameSettings();
                gameModel = new GameModel(ActualWidth, ActualHeight, gameSettings);
                gameLogic = new GameLogic(gameModel, gameSettings);
                gameRenderer = new GameRenderer.GameRenderer(gameModel, gameSettings);
                gameLogic.CallRefresh += (sender, args) => InvalidateVisual();
                window.KeyDown += Window_KeyDown;

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(130);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gameModel.GameAreaWidth = ActualWidth;
            gameModel.GameAreaHeight = ActualHeight;

            gameLogic.FoodItemsFalling();

            InvalidateVisual();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var entrance = false;
            switch (e.Key)
            {
                case Key.Left:
                    entrance=gameLogic.Move(-gameSettings.CaveManInitXVelocity, 0);
                    break;
                case Key.Right:
                    entrance = gameLogic.Move(gameSettings.CaveManInitXVelocity, 0);
                    break;
                case Key.A:
                    entrance = gameLogic.Move(-gameSettings.CaveManInitXVelocity, 0);
                    break;
                case Key.D:
                    entrance = gameLogic.Move(gameSettings.CaveManInitXVelocity, 0);
                    break;
                case Key.Down:
                    //new KitchenScreenWindow(gameModel).Show();
                    new KitchenScreenWindow(gameModel).Show();
                    entrance = gameLogic.Move(0, 0);
                    if (entrance)
                        new KitchenScreenWindow(gameModel).Show();
                    break;

            }
            



        }


        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameModel != null)
            {
                gameRenderer.Display(drawingContext);
            }
        }
    }
}
