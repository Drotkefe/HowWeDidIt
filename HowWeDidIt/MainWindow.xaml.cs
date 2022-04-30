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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

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
            mediaPlayer.Close();
            screen.Show();
            
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                new_game_button.BeginAnimation(WidthProperty, new DoubleAnimation(0, 450, TimeSpan.FromMilliseconds(1200)));
                leaderboard_button.BeginAnimation(WidthProperty, new DoubleAnimation(0, 450, TimeSpan.FromMilliseconds(1800)));
                exit_button.BeginAnimation(WidthProperty, new DoubleAnimation(0, 450, TimeSpan.FromMilliseconds(2500)));
            };
            
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }

        private void leaderboard_button_Click(object sender, RoutedEventArgs e)
        {
            LeaderBoardWindow screen = new LeaderBoardWindow();
            screen.Show();
        }
    }
}
