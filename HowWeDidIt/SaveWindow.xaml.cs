using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace HowWeDidIt
{
    /// <summary>
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        int Score { get; set; }
        public SaveWindow(int score)
        {
            InitializeComponent();
            Score = score;
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Player_Name.Text != "" && Player_Name.Text.Length < 10)
            {
                File.AppendAllText("leaderboard.txt", $"{Player_Name.Text} {Score}\n");
                MessageBox.Show($"~{Player_Name.Text}~ your game score is saved");
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Player name should be atlast one character");
            }
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
