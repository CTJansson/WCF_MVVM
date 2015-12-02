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
    class CreatePostViewModel : BaseViewModel
    {
        public ObservableCollection<NewsCategories> Categories { get; set; }
        private NewsServiceClient _client;
        private AdminAccount _account;
        private PostsManagementPage _postsManagementPage;

        public CreatePostViewModel()
        {
            _client = new NewsServiceClient();
            Categories = new ObservableCollection<NewsCategories>(_client.GetEveryCategory());
        }
        public CreatePostViewModel(AdminAccount account, PostsManagementPage postsmanagementpage)
            : this()
        {
            _account = account;
            _postsManagementPage = postsmanagementpage;
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

        #region CreatePost
        private string header;
        public string Header
        {
            get { return header; }
            set 
            { 
                header = value;
                NotifyPropertyChanged("Header");
            }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; NotifyPropertyChanged("Content");}
        }

        private string tags;
        public string Tags
        {
            get { return tags; }
            set { tags = value; NotifyPropertyChanged("Tags"); }
        }

        private NewsCategories selectedCategory;
        public NewsCategories SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; NotifyPropertyChanged("SelectedCategory"); }
        }

        private AllCommands createNewsPost;
        public ICommand CreateNewsPost
        {
            get
            {
                if (createNewsPost == null)
                {
                    createNewsPost = new AllCommands(OnCreateClick, CanUserAuthenticate);
                }

                return createNewsPost;
            }
        }

        private void OnCreateClick(object sender)
        {
            if (!string.IsNullOrEmpty(Header) && !string.IsNullOrEmpty(Content) && !string.IsNullOrEmpty(Tags) && selectedCategory != null)
            {
                AdminNewsPosts newsPost = new AdminNewsPosts
                {
                    Header = this.Header,
                    Content = this.Content,
                    Tags = this.Tags,
                    AuthorId = _account.AuthorId,
                    CategoryId = this.selectedCategory.Id,
                    WrittenBy = _account.Author.FirstName + " " + _account.Author.LastName,
                    Date = DateTime.Now,
                };

                _client.CreateNewsPost(newsPost);

                MainWindow main = Application.Current.MainWindow as MainWindow;

                main.MainFrame.Navigate(_postsManagementPage);
            }
        }

        private bool CanUserAuthenticate(object sender)
        {
            if (!string.IsNullOrEmpty(Header) && !string.IsNullOrEmpty(Content) && !string.IsNullOrEmpty(Tags) && selectedCategory != null)
            {
                return true;
            }

            return false;
        }
        
        #endregion
    }
}
