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

namespace KrishiKit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isMenuOpen = false;

        private void ToggleLogVisibilityButtonClicked(object sender, RoutedEventArgs e)
        {
            if (isMenuOpen)
            {
                System.Windows.Media.Animation.Storyboard _storyboard;
                _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
                _storyboard.Begin(menuCanvas);

                isMenuOpen = false;
            }
            else
            {
                System.Windows.Media.Animation.Storyboard sb;
                sb = Resources["ShowLog"] as System.Windows.Media.Animation.Storyboard;
                sb.Begin(menuCanvas);

                isMenuOpen = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();          
        }
    }
}
