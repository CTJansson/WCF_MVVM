using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Admin.Commands;
using WPF_Admin.NewsAppService;

namespace WPF_Admin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public SecureString SecuredPassWord { get; set; }
        private NewsServiceClient _client;

        public LoginViewModel()
        {
            _client = new NewsServiceClient();
            SecuredPassWord = new SecureString();
        }

        private AllCommands loginAdmin;
        public ICommand LoginAdmin
        {
            get
            {
                if (loginAdmin == null)
                {
                    loginAdmin = new AllCommands(OnLoginAdmin, CanUserAuthenticate);
                }

                return loginAdmin;
            }
        }

        private void OnLoginAdmin(object sender)
        {
            string unSecuredPassword = PasswordManager.ConvertToUnsecureString(SecuredPassWord);

            bool AuthenticationSuccessful = _client.UserAuthentication(UserName, unSecuredPassword);

            if (AuthenticationSuccessful)
            {
                MainWindow main = Application.Current.MainWindow as MainWindow;

                PostsManagementPage postManagementPage = new PostsManagementPage();
                postManagementPage.DataContext = new PostManagementViewModel(UserName, postManagementPage);
                main.MainFrame.Navigate(postManagementPage);
            }
        }

        private bool CanUserAuthenticate(object sender)
        {
            if (string.IsNullOrEmpty(UserName) && SecuredPassWord == null)
            {
                return false;
            }

            return true;
        }
        

        
    }
}
