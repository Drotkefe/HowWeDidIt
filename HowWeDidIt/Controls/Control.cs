using HowWeDidIt.BusinessLogic;
using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.GameRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HowWeDidIt.Controls
{
    public class Control : FrameworkElement
    {
        IGameSettings gameSettings;
        //IGameRepository gameRepository;
        IGameLogic gameLogic;
        IGameRenderer gameRenderer;

        public Control()
        {
            Loaded += HowWeDidIt_Controller_Loaded;
        }

        private void HowWeDidIt_Controller_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);

            if (window != null) // Window loaded
            {
                gameSettings = new GameSettings();
                gameLogic = new GameLogic(gameSettings);
                gameRenderer = new GameRenderer.GameRenderer(gameLogic.GameModel, gameSettings);
                gameLogic.CallRefresh += (sender, args) => InvalidateVisual();
                InvalidateVisual();
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    gameLogic.Move(-20, 0);
                    break;
                case Key.Right:
                    gameLogic.Move(20, 0);
                    break;
            }



        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameLogic != null && ActualWidth > 0)
            {
                drawingContext.DrawDrawing(gameRenderer.GetDrawing());
            }
        }
    }
}
