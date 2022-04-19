using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.Models;
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

namespace HowWeDidIt
{
    /// <summary>
    /// Interaction logic for KitchenScreenWindow.xaml
    /// </summary>
    public partial class KitchenScreenWindow : Window
    {
        public KitchenScreenWindowVM VM { get; set; }

        public KitchenScreenWindow(IGameModel gameModel)
        {
            InitializeComponent();


            VM = new KitchenScreenWindowVM(gameModel);
            DataContext = VM;


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
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    VM.UpgradeStorageCommand.Execute(Foods.Onion.ToString());
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
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    VM.UpgradeStorageCommand.Execute(Foods.Carrot.ToString());
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
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    VM.UpgradeStorageCommand.Execute(Foods.Potato.ToString());
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
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    VM.UpgradeStorageCommand.Execute(Foods.Uranium.ToString());
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
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    VM.UpgradeStorageCommand.Execute(Foods.Meat.ToString());
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
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    VM.UpgradeStorageCommand.Execute(Foods.Egg.ToString());
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

        //private void GarbageButton_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (sender is Button EggButton/* && e.RightButton == MouseButtonState.Pressed*/)
        //    {
                
        //    }
        //}

        private void GarbageButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button garbage)
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    VM.UpgradeStorageCommand.Execute("Garbage"); // Send "Garbage" string to logic
                }
            }
        }








        //private void RightClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    string typeOfCapacity = default;

        //    if (sender is Button button && e.RightButton == MouseButtonState.Pressed)
        //    {

        //        if (button.ToString() == "Garbage" )
        //        {
        //            ;
        //        }


        //    }

        //    if (sender is Button GarbageButton/* && e.LeftButton == MouseButtonState.Pressed*/)
        //    {
        //        typeOfCapacity = "Garbage";
        //    }

        //    VM.UpgradeStorageCommand.Execute(typeOfCapacity);

        //    //vm.SelectEntryCommand.Execute(null);
        //}





        //private void Button_Drop(object sender, DragEventArgs e)
        //{
        //    VM.Ingredients.OnionCount++;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e) //TODO: delete
        //{
        //    VM.Ingredients.OnionCount++; 
        //}
    }
}
