using MagicApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace MegaTaroCard
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private SoundPlayer _soundPlayer;

        public Main()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainWindow());
            var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "glamur.wav");
            _soundPlayer = new SoundPlayer(filePath);
            PlaySound();
        }

        private void OpenAiTaroWindow(object sender, RoutedEventArgs e)
        {
            ((Main)Application.Current.MainWindow).MainFrame.Navigate(new ai_taro());
        }

        private void OpenAllTarosWindow(object sender, RoutedEventArgs e)
        {
            ((Main)Application.Current.MainWindow).MainFrame.Navigate(new gl());
        }

        private void PlaySound()
        {
            try
            {
                _soundPlayer.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка воспроизведения: {ex.Message}");
            }
        }
    }
}
