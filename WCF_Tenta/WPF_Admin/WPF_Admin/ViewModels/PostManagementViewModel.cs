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
using WPF_Admin.Views;

namespace WPF_Admin.ViewModels
{
    public class PostManagementViewModel : BaseViewModel
    {
        private string _username;
        public string NickName { get; private set; }
        public ObservableCollection<AdminNewsPosts> NewsPosts { get; private set; }
        private NewsServiceClient _client;
        private AdminAccount _account;
        private PostsManagementPage _postsManagementPage;

        public PostManagementViewModel(string username, PostsManagementPage postsmanagementpage)
            : this()
        {
            _username = username;
            _account = _client.GetLoggedInAdminAccount(_username);
            _postsManagementPage = postsmanagementpage;
            NickName = _account.Author.FirstName + " " + _account.Author.LastName;
            NotifyPropertyChanged("NickName");
            
        }
        public PostManagementViewModel()
        {
            _client = new NewsServiceClient();
            NewsPosts = new ObservableCollection<AdminNewsPosts>(_client.GetAllNewsPosts());
        }

        #region EntertainmentNews
        private AllCommands getEntertainmentNews;
        public ICommand GetEntertainmentNews
        {
            get
            {
                if (getEntertainmentNews == null)
                {
                    getEntertainmentNews = new AllCommands(EntertainmentNewsClick);
                }

                return getEntertainmentNews;
            }
        }

        private void EntertainmentNewsClick(object sender)
        {
            AdminNewsPosts[] temp = _client.GetFilteredNewsPosts(5);

            if (temp != null)
            {
                NewsPosts.Clear();
                foreach (var newspost in temp)
                {
                    NewsPosts.Add(newspost);
                }
            }
        }
        #endregion

        #region TechnologyNews
        private AllCommands getTechnologyNews;
        public ICommand GetTechnologyNews
        {
            get
            {
                if (getTechnologyNews == null)
                {
                    getTechnologyNews = new AllCommands(TechNewsClick);
                }

                return getTechnologyNews;
            }
        }

        private void TechNewsClick(object sender)
        {

            AdminNewsPosts[] temp = _client.GetFilteredNewsPosts(4);

            if (temp != null)
            {
                NewsPosts.Clear();
                foreach (var newspost in temp)
                {
                    NewsPosts.Add(newspost);
                }
            }
        }
        #endregion

        #region SportNews
        private AllCommands getSportNews;
        public ICommand GetSportNews
        {
            get
            {
                if (getSportNews == null)
                {
                    getSportNews = new AllCommands(SportNewsClick);
                }

                return getSportNews;
            }
        }

        private void SportNewsClick(object sender)
        {

            AdminNewsPosts[] temp = _client.GetFilteredNewsPosts(3);

            if (temp != null)
            {
                NewsPosts.Clear();
                foreach (var newspost in temp)
                {
                    NewsPosts.Add(newspost);
                }
            }
        }
        #endregion

        #region WorldNews
        private AllCommands getWorldNews;
        public ICommand GetWorldNews
        {
            get
            {
                if (getWorldNews == null)
                {
                    getWorldNews = new AllCommands(WorldNewsClick);
                }

                return getWorldNews;
            }
        }

        private void WorldNewsClick(object sender)
        {

            AdminNewsPosts[] temp = _client.GetFilteredNewsPosts(2);

            if (temp != null)
            {
                NewsPosts.Clear();
                foreach (var newspost in temp)
                {
                    NewsPosts.Add(newspost);
                }
            }
        }
        #endregion

        #region NationalNews
        private AllCommands getNationalNews;
        public ICommand GetNationalNews
        {
            get
            {
                if (getNationalNews == null)
                {
                    getNationalNews = new AllCommands(NationalNewsClick);
                }

                return getNationalNews;
            }
        }

        private void NationalNewsClick(object sender)
        {

            AdminNewsPosts[] temp = _client.GetFilteredNewsPosts(1);

            if (temp != null)
            {
                NewsPosts.Clear();
                foreach (var newspost in temp)
                {
                    NewsPosts.Add(newspost);
                }
            }
        }
        #endregion

        #region AllNews
        private AllCommands getAllNews;
        public ICommand GetAllNews
        {
            get
            {
                if (getAllNews == null)
                {
                    getAllNews = new AllCommands(AllNewsClick);
                }

                return getAllNews;
            }
        }

        private void AllNewsClick(object sender)
        {

            AdminNewsPosts[] temp = _client.GetAllNewsPosts();

            if (temp != null)
            {
                NewsPosts.Clear();
                foreach (var newspost in temp)
                {
                    NewsPosts.Add(newspost);
                }
            }
        }
        #endregion

        #region CreatePost
        private AllCommands showCreatePostWindow;
        public ICommand ShowCreatePostWindow
        {
            get
            {
                if (showCreatePostWindow == null)
                {
                    showCreatePostWindow = new AllCommands(OnCreatePostClick);
                }

                return showCreatePostWindow;
            }
        }

        private void OnCreatePostClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            CreatePostPage createPostPage = new CreatePostPage();
            createPostPage.DataContext = new CreatePostViewModel(_account, _postsManagementPage);

            main.MainFrame.Navigate(createPostPage);
        }
        #endregion

        private AllCommands quitApplication;
        public ICommand QuitApplication
        {
            get
            {
                if (quitApplication == null)
                {
                    quitApplication = new AllCommands(OnQuitApplcationClick);
                }

                return quitApplication;
            }
        }

        private void OnQuitApplcationClick(object sender)
        {
            Application.Current.Shutdown();
        }

        #region EditPost
        private AllCommands showEditPostPage;
        public ICommand ShowEditPostPage
        {
            get
            {
                if (showEditPostPage == null)
                {
                    showEditPostPage = new AllCommands(OnEditPostClick);
                }

                return showEditPostPage;
            }
        }

        private void OnEditPostClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            EditPostPage editPostPage = new EditPostPage();
            editPostPage.DataContext = new EditPostViewModel(_account, _postsManagementPage);

            main.MainFrame.Navigate(editPostPage);
        }
        #endregion

        #region DeletePost
        private AllCommands showDeletePostPage;
        public ICommand ShowDeletePostPage
        {
            get
            {
                if (showDeletePostPage == null)
                {
                    showDeletePostPage = new AllCommands(OnDeletePostClick);
                }

                return showDeletePostPage;
            }
        }

        private void OnDeletePostClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            DeletePostPage deletePostPage = new DeletePostPage();
            deletePostPage.DataContext = new DeletePostViewModel(_account, _postsManagementPage);

            main.MainFrame.Navigate(deletePostPage);
        }
        #endregion
    }
}
