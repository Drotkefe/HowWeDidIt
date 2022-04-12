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

    }
}
