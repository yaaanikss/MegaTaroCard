using MagicApp;
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
using System.Windows.Shapes;

namespace MegaTaroCard
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenAiTaroWindow(object sender, RoutedEventArgs e)
        {
             ((Main)Application.Current.MainWindow).MainFrame.Navigate(new ai_taro());
        }

        private void OpenAllTarosWindow(object sender, RoutedEventArgs e)
        {
            ((Main)Application.Current.MainWindow).MainFrame.Navigate(new gl());
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрыть текущее окно
            this.CloseButton_Click();
        }

        private void CloseButton_Click()
        {
            Application.Current.Shutdown();
        }
    }
}
