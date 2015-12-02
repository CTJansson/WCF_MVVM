using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Admin.Commands;
using WPF_Admin.NewsAppService;

namespace WPF_Admin.ViewModels
{
    class DeletePostViewModel : BaseViewModel
    {
        public ObservableCollection<AdminNewsPosts> authorPosts { get; private set; }

        private NewsServiceClient _client;
        private AdminAccount _account;
        private PostsManagementPage _postsManagementPage;

        public DeletePostViewModel()
        {
            _client = new NewsServiceClient();
        }
        public DeletePostViewModel(AdminAccount account, PostsManagementPage postsmanagementpage)
            : this()
        {
            _account = account;
            _postsManagementPage = postsmanagementpage;

            authorPosts = new ObservableCollection<AdminNewsPosts>(_client.GetAuthorNewsposts(_account.AuthorId));
        }

        #region BackToPreviousPage
        private AllCommands backToPreviousPage;
        public ICommand BackToPreviousPage
        {
            get
            {
                if (backToPreviousPage == null)
                {
                    backToPreviousPage = new AllCommands(OnCancelClick);
                }

                return backToPreviousPage;
            }
        }

        private void OnCancelClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;

            main.MainFrame.Navigate(_postsManagementPage);
        }
        #endregion

        #region DeletePost

        #region EditPost
        private AdminNewsPosts selectedNewsPost;
        public AdminNewsPosts SelectedNewsPost
        {
            get { return selectedNewsPost; }
            set { selectedNewsPost = value; NotifyPropertyChanged("SelectedNewsPost"); }
        }

        private AllCommands deletePost;
        public ICommand DeletePost
        {
            get
            {
                if (deletePost == null)
                {
                    deletePost = new AllCommands(OnDeleteClick, CanUserDeletePost);
                }

                return deletePost;
            }
        }

        private void OnDeleteClick(object sender)
        {
            if (selectedNewsPost != null)
            {
                _client.DeleteNewsPost(selectedNewsPost.Id);
                authorPosts.Remove(selectedNewsPost);

                MainWindow main = Application.Current.MainWindow as MainWindow;

                main.MainFrame.Navigate(_postsManagementPage);
            }
        }

        private bool CanUserDeletePost(object sender)
        {
            if (SelectedNewsPost != null)
            {
                return true;
            }

            return false;
        }

        #endregion

        #endregion
    }
}
