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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer=new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            mediaPlayer.Open(new Uri(string.Format("{0}\\menu_music.wav",AppDomain.CurrentDomain.BaseDirectory)));
            mediaPlayer.Play();
            mediaPlayer.Volume=0.1;
        }

        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            GameScreen screen = new GameScreen();
            screen.Show();
            mediaPlayer.Stop();
            Close();
        }

       
    }
}
