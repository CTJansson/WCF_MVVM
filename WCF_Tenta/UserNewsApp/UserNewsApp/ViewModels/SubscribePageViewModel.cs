using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserNewsApp.Commands;
using UserNewsApp.Views;
using UserNewsApp.UserNewsAppService;

namespace UserNewsApp.ViewModels
{
    public class SubscribePageViewModel : BaseViewModel
    {
        private CategoryPage _categoryPage;
        private UserNewsAppServiceClient _client;

        public SubscribePageViewModel()
        {
            _client = new UserNewsAppServiceClient();
        }
        public SubscribePageViewModel(CategoryPage categoryPage)
            : this()
        {
            _categoryPage = categoryPage;
        }

        #region BackToPreviousPage
        private RelayCommand backToPreviousPage;
        public ICommand BackToPreviousPage
        {
            get
            {
                if (backToPreviousPage == null)
                {
                    backToPreviousPage = new RelayCommand(BackToPreviousPageClick);
                }

                return backToPreviousPage;
            }
        }

        private void BackToPreviousPageClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            main.MainFrame.Navigate(_categoryPage);
        }
        #endregion

        #region Subscribe
        private string subscribeEmail;

        public string SubscribeEmail
        {
            get { return subscribeEmail; }
            set { subscribeEmail = value.ToLower(); NotifyPropertyChanged("SubscribeEmail"); }
        }
        
        private RelayCommand subscribe;
        public ICommand Subscribe
        {
            get
            {
                if (subscribe == null)
                {
                    subscribe = new RelayCommand(SubscribeClick);
                }

                return subscribe;
            }
        }

        private void SubscribeClick(object sender)
        {
            bool DidUserSubscribe = _client.Subscribe(SubscribeEmail);

            if (DidUserSubscribe)
            {
                MessageBox.Show("You are now subscribed");
                MainWindow main = Application.Current.MainWindow as MainWindow;
                main.MainFrame.Navigate(_categoryPage);
            }
            else
            {
                MessageBox.Show("Something went wrong, please try again");
            }
        }

        private bool CanUserSubscribe(object sender)
        {
            if (string.IsNullOrEmpty(SubscribeEmail))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Unsubscribe
        private string unsubScribeEmail;

        public string UnsubscribeEmail
        {
            get { return unsubScribeEmail; }
            set { unsubScribeEmail = value.ToLower(); NotifyPropertyChanged("UnsubscribeEmail"); }
        }
        

        private RelayCommand unsubscribe;
        public ICommand Unsubscribe
        {
            get
            {
                if (unsubscribe == null)
                {
                    unsubscribe = new RelayCommand(UnsubscribeClick, CanUserUnsubscribe);
                }

                return unsubscribe;
            }
        }

        private void UnsubscribeClick(object sender)
        {
            bool CanUserUnsubscribe = _client.Unsubscribe(unsubScribeEmail);

            if (CanUserUnsubscribe)
            {
                MessageBox.Show("You are now unsubscribed");
                MainWindow main = Application.Current.MainWindow as MainWindow;
                main.MainFrame.Navigate(_categoryPage);
            }
            else
            {
                MessageBox.Show("Couldn't find your email in subscribers list");
            }
        }

        private bool CanUserUnsubscribe(object sender)
        {
            if (string.IsNullOrEmpty(UnsubscribeEmail))
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
