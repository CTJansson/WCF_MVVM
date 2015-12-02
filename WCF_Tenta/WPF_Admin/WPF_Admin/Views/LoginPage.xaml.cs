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
using WPF_Admin.NewsAppService;

namespace WPF_Admin
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RemoveUsernameLabel(object sender, RoutedEventArgs e)
        {
            labelUsername.Visibility = Visibility.Hidden;
        }

        private void ShowUsernameLabelIfStringEmpty(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text == string.Empty)
            {
                labelUsername.Visibility = Visibility.Visible;
            }
        }

        private void ShowPasswordLabelIfStringEmpty(object sender, RoutedEventArgs e)
        {
            if (passwordBoxPassword.Password == string.Empty)
            {
                labelPassword.Visibility = Visibility.Visible;
            }
        }

        private void RemovePasswordLabel(object sender, RoutedEventArgs e)
        {
            labelPassword.Visibility = Visibility.Hidden;
        }

        private void CollectPasswordAsString(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).SecuredPassWord = ((PasswordBox)sender).SecurePassword; }
        }
    }
}
