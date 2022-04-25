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

        private void OnionButton_MouseMove(object sender, MouseEventArgs e) // TESTER BUTTON
        {
            if (sender is Button OnionButton)
            {
                if (true)   // <----------------------------  e.LeftButton == MouseButtonState.Pressed  // MIÉRT NEM LÉP BELE?????
                {
                DragDrop.DoDragDrop(OnionButton, Foods.Onion.ToString() , DragDropEffects.Copy);
                }
                if (e.RightButton == MouseButtonState.Pressed)
                {                 
                VM.UpgradeStorageCommand.Execute(Foods.Onion.ToString());
                }
            }

        }


        private void CarrotButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button CarrotButton/* && e.LeftButton == MouseButtonState.Pressed*/)
            {
                DragDrop.DoDragDrop(CarrotButton, Foods.Carrot.ToString(), DragDropEffects.Copy);
            }
        }



        private void PotatoButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button PotatoButton/* && e.LeftButton == MouseButtonState.Pressed*/)
            {
                DragDrop.DoDragDrop(PotatoButton, Foods.Potato.ToString(), DragDropEffects.Copy);
            }
        }

        private void UraniumButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button UraniumButton/* && e.LeftButton == MouseButtonState.Pressed*/)
            {
                DragDrop.DoDragDrop(UraniumButton, Foods.Uranium.ToString(), DragDropEffects.Copy);
            }
        }

        private void MeatButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button MeatButton/* && e.LeftButton == MouseButtonState.Pressed*/)
            {
                DragDrop.DoDragDrop(MeatButton, Foods.Meat.ToString(), DragDropEffects.Copy);
            }
        }
        private void EggButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button EggButton/* && e.LeftButton == MouseButtonState.Pressed*/)
            {
                DragDrop.DoDragDrop(EggButton, Foods.Egg.ToString(), DragDropEffects.Copy);
            }
        }


        private void Button_Drop(object sender, DragEventArgs e)
        {
            if (sender is Button pot)
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    //Foods stringFrimDrop = (Foods)Enum.Parse(typeof(Foods), (string)e.Data.GetData(DataFormats.StringFormat)); // if i would like to send enum instead of string
                    VM.FoodToPotCommand.Execute(e.Data.GetData(DataFormats.StringFormat));
                }
            }
        }

        private void GarbageButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button EggButton/* && e.RightButton == MouseButtonState.Pressed*/)
            {
                VM.UpgradeStorageCommand.Execute("Garbage");
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
