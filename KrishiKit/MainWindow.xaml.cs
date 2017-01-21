using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
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

        public void loginButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindow window = ((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as MainWindow);
            if (loginSignup.Login(window.loginUsername.Text, window.loginPass.Password) == false)
            {
                MessageBox.Show("Invalid Credentials");
            }
            else
            {

            }
        }

        public void signupButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindow window = ((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as MainWindow);
            if (loginSignup.SignUp(window.loginUsername.Text, window.loginPass.Password) == false)
            {
                MessageBox.Show("Failed to signup");
            }
            else
            {

            }
        }

        public MainWindow()
        {
            InitializeComponent();
            //string page_source = "http://farmer.gov.in/mspstatements.aspx";
           // MSPGrid.DataContext =   MSP.getMSP() ;
            
        }
    }
}
