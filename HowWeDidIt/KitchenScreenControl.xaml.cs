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

        private void OnionButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button OnionButton)// && e.LeftButton == MouseButtonState.Pressed)
            {               
                //DragDrop.DoDragDrop(OnionButton, OnionButton, DragDropEffects.Copy);
                DragDrop.DoDragDrop(OnionButton, Foods.Onion.ToString() , DragDropEffects.None);
                ;
            }
        }

        private void Button_Drop(object sender, DragEventArgs e)
        {
            if (sender is Button pot)
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    Foods stringFrimDrop = (Foods)Enum.Parse(typeof(Foods), (string)e.Data.GetData(DataFormats.StringFormat));

                }
            }
        }

        private void Style_Selected(object sender, RoutedEventArgs e)
        {

        }



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
