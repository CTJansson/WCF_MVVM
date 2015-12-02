using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserNewsApp.Commands;
using UserNewsApp.UserNewsAppService;
using UserNewsApp.Views;

namespace UserNewsApp.ViewModels
{
    public class ReadNewsPageViewModel
    {
        public ObservableCollection<UserNewsPost> NewsPosts { get; set; }
        private UserNewsAppServiceClient _client;
        private CategoryPage _page;
        private int _id;

        public ReadNewsPageViewModel()
        {
            _client = new UserNewsAppServiceClient();
        }
        public ReadNewsPageViewModel(int id, CategoryPage page)
            : this()
        {
            _id = id;
            _page = page;

            if (_id >= 1)
            {
                NewsPosts = new ObservableCollection<UserNewsPost>(_client.GetFilteredNewsPosts(_id));
            }
            else
            {
                NewsPosts = new ObservableCollection<UserNewsPost>(_client.GetAllNewsPosts());
            }   
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
            main.MainFrame.Navigate(_page);
        }
        #endregion
    }
}
