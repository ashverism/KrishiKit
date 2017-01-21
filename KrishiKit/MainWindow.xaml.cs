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
        public Panel openPanel;
        public bool isMenuOpen = false;
        public bool isLoggedIn = false;
        public string username = "";

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
                isLoggedIn = true;
            }
        }

        public void signupButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindow window = ((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as MainWindow);
            if (window.loginUsername.Text == "" || window.loginPass.Password == "" ||loginSignup.SignUp(window.loginUsername.Text, window.loginPass.Password) == false)
            {
                window.signupError.Visibility = Visibility.Visible;
                window.signupError.Text = "Error Signing Up";
            }
            else
            {
                isLoggedIn = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            openPanel = homePanel;
            //string page_source = "http://farmer.gov.in/mspstatements.aspx";
           // MSPGrid.DataContext =   MSP.getMSP() ;
            
        }

        private void showLoginPanel(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            loginPanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = loginPanel;

            isMenuOpen = false;
        }

        private void showHome(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            homePanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = homePanel;

            isMenuOpen = false;
        }

        private void showSignupPanel(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            signupPanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = signupPanel;

            isMenuOpen = false;
        }

        private void showInsurancePanel(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            insurancePanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = insurancePanel;

            isMenuOpen = false;
        }

        private void showMSPPanel(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            mspPanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = mspPanel;

            (mspPanel.Children[0] as DataGrid).DataContext = MSP.getMSP();

            isMenuOpen = false;
        }

        private void showVideosPanel(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            videosPanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = videosPanel;

            isMenuOpen = false;
        }

    }
}
