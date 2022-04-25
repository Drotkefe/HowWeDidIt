using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
using HowWeDidIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HowWeDidIt
{
    /// <summary>
    /// Interaction logic for KitchenScreenWindow.xaml
    /// </summary>
    public partial class KitchenScreenWindow : Window
    {

        

        public KitchenScreenWindowVM VM { get; set; }


        DispatcherTimer timer;

        public KitchenScreenWindow(IGameModel gameModel)
        {
            InitializeComponent();


      

            VM = new KitchenScreenWindowVM(gameModel);
            DataContext = VM;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void OnionEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse onionEllipse)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    //MessageBox.Show("The Left Mouse Button is pressed"); //TESZT

                    DragDrop.DoDragDrop(onionEllipse, Foods.Onion.ToString(), DragDropEffects.Copy);
                }
            }

        }
        private void CarrotEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse carrotEllipse)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(carrotEllipse, Foods.Carrot.ToString(), DragDropEffects.Copy);
                }
            }
        }
        private void PotatoEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse potatoEllipse)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(potatoEllipse, Foods.Potato.ToString(), DragDropEffects.Copy);
                }
            }
        }
        private void UraniumEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse uraniumEllipse)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(uraniumEllipse, Foods.Uranium.ToString(), DragDropEffects.Copy);
                }
            }
        }
        private void MeatEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse meatEllipse)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(meatEllipse, Foods.Meat.ToString(), DragDropEffects.Copy);
                }
            }
        }
        private void EggEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Ellipse eggEllipse)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(eggEllipse, Foods.Egg.ToString(), DragDropEffects.Copy);
                }
            }
        }

        private void Button_Drop(object sender, DragEventArgs e)
        {
            if (sender is Button pot)
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    //// if i would like to send enum instead of string:::
                    //Foods stringFrimDrop = (Foods)Enum.Parse(typeof(Foods), (string)e.Data.GetData(DataFormats.StringFormat)); 

                    VM.FoodToPotCommand.Execute(e.Data.GetData(DataFormats.StringFormat));
                }
            }
        }



        private void OnionEllipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            VM.UpgradeStorageCommand.Execute(Foods.Onion.ToString());
        }
        private void CarrotEllipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            VM.UpgradeStorageCommand.Execute(Foods.Carrot.ToString());
        }
        private void PotatoEllipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            VM.UpgradeStorageCommand.Execute(Foods.Potato.ToString());
        }
        private void UraniumEllipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            VM.UpgradeStorageCommand.Execute(Foods.Uranium.ToString());
        }
        private void MeatEllipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            VM.UpgradeStorageCommand.Execute(Foods.Meat.ToString());
        }
        private void EggEllipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            VM.UpgradeStorageCommand.Execute(Foods.Egg.ToString());
        }
        private void GarbageButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (sender is Button garbage)
            //{
            //    if (e.RightButton == MouseButtonState.Pressed)
            //    {
                    VM.UpgradeStorageCommand.Execute("Garbage"); // Send "Garbage" string to logic
                //}
            //}
        }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            
            //GameScreen screen = new GameScreen(gameModel);

            GameScreen screen = new GameScreen();
            screen.Show();
            timer.Stop();
            timer.Tick -= timer_Tick;
            Close();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            VM.DecreaseHealt();
        }


    }
}
