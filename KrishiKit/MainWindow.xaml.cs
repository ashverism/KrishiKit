using System.Windows;
using System.Windows.Controls;

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
            if (loginSignup.Login(window.loginUsername.Text, window.loginPass.Password, (bool)rb3.IsChecked) == false)
            {
                MessageBox.Show("Invalid Credentials");
            }
            else
            {
                isLoggedIn = true;
                showCropSuggestionPanel(null, null);
            }
        }

        public void signupButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindow window = ((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as MainWindow);
            if (window.signUpUsername.Text == "" || window.signUpPass.Password == "" ||loginSignup.SignUp(window.loginUsername.Text, window.loginPass.Password, (bool)rb1.IsChecked) == false)
            {
                window.signupError.Visibility = Visibility.Visible;
                window.signupError.Text = "Error Signing Up";
            }
            else
            {
                isLoggedIn = true;
                showCropSuggestionPanel(null, null);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            openPanel = homePanel;
            //string page_source = "http://farmer.gov.in/mspstatements.aspx";
            // MSPGrid.DataContext =   MSP.getMSP() ;
            string[] tokens = new string[] { "Anantpur", "Chittoor", "Nellore", "Visakhapatnam", "Ahmadabad", "Bhavnagar", "Kachchh", "Rajkot", "Amravati", "Bhandara", "Chandrapur", "Nagpur", "Debagarh", "Jharsuguda", "Nayagarh", "Puri" };
            for (int i = 0; i < 16; i++)
                cb1.Items.Add(tokens[i]);
            string[] states = new string[] { "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu and Kashmir", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttarakhand", "Uttar Pradesh", "West Bengal", "Andaman and Nicobar Islands", "Chandigarh", "Dadra and Nagar Haveli", "Daman and Diu", "Delhi", "Lakshadweep", "Puducherry" };
            for (int j = 0; j < 36; j++)
                cb2.Items.Add(states[j]);

        }

        private void showLoginPanel(object sender, RoutedEventArgs e)
        {
            if (isLoggedIn)
            {
                showCropSuggestionPanel(null, null);
                return;
            }
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
            if (isLoggedIn)
            {
                showCropSuggestionPanel(null, null);
                return;
            }
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

        private void showCropSuggestionPanel(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            cropSuggestionPanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = cropSuggestionPanel;
            
            isMenuOpen = false;
        }

        private void showWeatherPanel(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            weatherPanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = weatherPanel;

            functions.Calling();
            (weatherPanel.Children[0] as DataGrid).DataContext = functions.weatherDataTable;

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

        private void showFPPanel(object sender, RoutedEventArgs e)
        {
            openPanel.Margin = new Thickness(-5000, -5000, 0, 0);
            fertilisersPesticidesPanel.Margin = new Thickness(52, 57, 0, 0);
            System.Windows.Media.Animation.Storyboard _storyboard;
            _storyboard = Resources["HideLog"] as System.Windows.Media.Animation.Storyboard;
            _storyboard.Begin(menuCanvas);
            openPanel = fertilisersPesticidesPanel;

            isMenuOpen = false;
        }

        private void showSuggestions(object sender, RoutedEventArgs e)
        {
            string state = (string)cb2.SelectedValue;
            string season;
            if ((bool)rb5.IsChecked)
            {
                season = "khareef";
            }else if ((bool)rb6.IsChecked)
            {
                season = "rabi";
            }else if ((bool)rb6.IsChecked)
            {
                season = "zaid";
            }else
            {
                return;
            }
            string suggestion = SuggestCrops.getSuggestion(state, season);
            if(suggestion == "")
            {
                suggestion = "No suggestions available";
            }
            suggestionBox.Visibility = Visibility.Visible;
            suggestionBox.Text = suggestion;
        }

        private void showFPData(object sender, RoutedEventArgs e)
        {
            bool isFertilisers = (bool)radioButton.IsChecked;

            (fertilisersPesticidesPanel.Children[4] as DataGrid).Visibility = Visibility.Visible;

            if (isFertilisers)
            {
                (fertilisersPesticidesPanel.Children[4] as DataGrid).DataContext = ExcelSheet.viewExcelFertiliser((string)cb1.SelectedValue);
            }
            else
            {
                (fertilisersPesticidesPanel.Children[4] as DataGrid).DataContext = ExcelSheet.viewExcelPesticides((string)cb1.SelectedValue);
            }
        }
    }
}
