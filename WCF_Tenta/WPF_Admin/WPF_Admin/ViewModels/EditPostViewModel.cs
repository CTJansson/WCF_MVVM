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
    class EditPostViewModel : BaseViewModel
    {
        private NewsServiceClient _client;
        private AdminAccount _account;
        private PostsManagementPage _postsManagementPage;
        public ObservableCollection<AdminNewsPosts> authorPosts { get; private set; }
        public ObservableCollection<NewsCategories> Categories { get; private set; }


        public EditPostViewModel()
        {
            _client = new NewsServiceClient();
            Categories = new ObservableCollection<NewsCategories>(_client.GetEveryCategory());
        }
        public EditPostViewModel(AdminAccount account, PostsManagementPage postsmanagementpage)
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

        #region EditPost
        private AdminNewsPosts selectedNewsPost;
        public AdminNewsPosts SelectedNewsPost
        {
            get { return selectedNewsPost; }
            set { selectedNewsPost = value; NotifyPropertyChanged("SelectedNewsPost"); }
        }

        private AllCommands editNewsPost;
        public ICommand EditNewsPost
        {
            get
            {
                if (editNewsPost == null)
                {
                    editNewsPost = new AllCommands(OnEditClick, CanUserEditPost);
                }

                return editNewsPost;
            }
        }

        private void OnEditClick(object sender)
        {
            if (SelectedNewsPost != null)
            {
                AdminNewsPosts newsPost = new AdminNewsPosts
                {
                    Header = selectedNewsPost.Header,
                    Content = selectedNewsPost.Content,
                    Tags = selectedNewsPost.Tags,
                    AuthorId = selectedNewsPost.AuthorId,
                    CategoryId = selectedNewsPost.CategoryId,
                };

                _client.EditNewsPost(selectedNewsPost.Id, newsPost);

                MainWindow main = Application.Current.MainWindow as MainWindow;

                main.MainFrame.Navigate(_postsManagementPage);
            }
        }

        private bool CanUserEditPost(object sender)
        {
            if (SelectedNewsPost != null && !string.IsNullOrEmpty(selectedNewsPost.Header) && !string.IsNullOrEmpty(selectedNewsPost.Content))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
