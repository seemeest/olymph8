using Org.BouncyCastle.Asn1.IsisMtt.X509;
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

namespace olymph8
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            //AuthMenu

            DoubleAnimation AuthMenuAnimation = new DoubleAnimation();

            AuthMenuAnimation.From = 0;
            AuthMenuAnimation.To = 400;
            AuthMenuAnimation.Duration = TimeSpan.FromMilliseconds(600);
            AuthMenu.BeginAnimation(StackPanel.WidthProperty, AuthMenuAnimation);
        }
        DataBaeController dataBaeController = new DataBaeController();
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            TextBlock authErr = (TextBlock)FindName("AuthErr");
            authErr.Visibility = Visibility.Hidden;
            TextBox pasword = (TextBox)FindName("pasword");
            TextBox login = (TextBox)FindName("login");

            if (!dataBaeController.auth(login.Text, pasword.Text)) authErr.Visibility = Visibility.Visible;
            else
            {

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow)) { 
                    
                    
                        switch(ThisUsers.role)
                        {
                            case "admin":
                                (window as MainWindow).MainFrame.Content = new АdministratorPage();
                                break;
                        }
                    }
                }
               
            }
        }
    }
}
