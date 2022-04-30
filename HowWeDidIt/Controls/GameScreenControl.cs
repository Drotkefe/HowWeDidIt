using GalaSoft.MvvmLight.Messaging;
using HowWeDidIt.BusinessLogic;
using HowWeDidIt.Core.GameSettings;
using HowWeDidIt.GameRenderer;
using HowWeDidIt.GameRenderer.Helpers;
using HowWeDidIt.Models;
using HowWeDidIt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        IGameRepository gameRepository;
        IGameModel gameModel;
        IGameLogic gameLogic;
        IGameRenderer gameRenderer;
        IKitchenService kitchenService;
        DispatcherTimer timer;
        DispatcherTimer timer_vitality;
        IMessenger messenger;

        private MediaPlayer mediaPlayer = new MediaPlayer();

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
                mediaPlayer.Open(new Uri(string.Format("{0}\\gameplay_music.mp3", AppDomain.CurrentDomain.BaseDirectory)));
                mediaPlayer.Play();
                mediaPlayer.Volume = 0.1;
                gameSettings = new GameSettings();
                gameRepository = new GameRepository(ActualWidth, ActualHeight, gameSettings);
                
                if (gameRepository.GetGameModel() == null) // mentés nem létezik
                {
                   gameModel = new GameModel(ActualWidth, ActualHeight, gameSettings);
                }
                else
                {
                    gameModel = gameRepository.GetGameModel();
                }
                                
                kitchenService = new KitchenService(messenger); 
                gameLogic = new GameLogic(gameModel, gameSettings, gameRepository, kitchenService);
                gameLogic.InitRecipe();
                gameRenderer = new GameRenderer.GameRenderer(gameModel, gameSettings);
                gameLogic.CallRefresh += (sender, args) => InvalidateVisual();
                window.KeyDown += Window_KeyDown;

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(130);
                timer.Tick += Timer_Tick;
                timer.Start();


                timer_vitality = new DispatcherTimer();
                timer_vitality.Interval = TimeSpan.FromMilliseconds(500);
                timer_vitality.Tick += Timer_Vitality_Tick;
                timer_vitality.Start();
            }
            window.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            gameLogic.Save(gameModel);
            MessageBox.Show("Saved your current game state for later....");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gameModel.GameAreaWidth = ActualWidth;
            gameModel.GameAreaHeight = ActualHeight;

            gameLogic.FoodItemsFalling();

            foreach (var foodItem in gameModel.FoodItems)
            {
                if (LogicHelper.HasBeenCaught(gameModel.CaveMan, foodItem))
                {
                    gameLogic.FoodItemCaught(foodItem);
                }
            }

            InvalidateVisual();
        }
        private void Timer_Vitality_Tick(object sender, EventArgs e)
        {
            gameLogic.DecreaseHealth();
            if (gameModel.Vitality == 0)
            {
                gameRepository.Reset_Save();
                MessageBox.Show("The Game is Over");
                SaveWindow save = new SaveWindow(gameModel.GameScore);
                save.Show();
            }
            InvalidateVisual();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var entrance = false;
            var window = Window.GetWindow(this);
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
                    entrance = gameLogic.Move(0, 0);
                    if (entrance)
                    {
                        new KitchenScreenWindow(gameModel).Show();
                    }
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
