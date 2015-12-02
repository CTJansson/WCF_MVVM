using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserNewsApp.Commands;
using UserNewsApp.Views;

namespace UserNewsApp.ViewModels
{
    public class CategoryPageViewModel
    {
        private CategoryPage _categoryPage;
        private ReadNewsPage _readNewsPage;
        private SubscribePage _subscribePage;

        public CategoryPageViewModel()
        {
            _readNewsPage = new ReadNewsPage();
            _subscribePage = new SubscribePage();
        }
        public CategoryPageViewModel(CategoryPage categoryPage)
            : this()
        {
            _categoryPage = categoryPage;
        }

        #region EntertainmentNews
        private RelayCommand getEntertainmentNews;
        public ICommand GetEntertainmentNews
        {
            get
            {
                if (getEntertainmentNews == null)
                {
                    getEntertainmentNews = new RelayCommand(EntertainmentNewsClick);
                }

                return getEntertainmentNews;
            }
        }

        private void EntertainmentNewsClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            _readNewsPage.DataContext = new ReadNewsPageViewModel(5, _categoryPage);
            main.MainFrame.Navigate(_readNewsPage);
        }
        #endregion

        #region TechnologyNews
        private RelayCommand getTechnologyNews;
        public ICommand GetTechnologyNews
        {
            get
            {
                if (getTechnologyNews == null)
                {
                    getTechnologyNews = new RelayCommand(TechNewsClick);
                }

                return getTechnologyNews;
            }
        }

        private void TechNewsClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            _readNewsPage.DataContext = new ReadNewsPageViewModel(4, _categoryPage);
            main.MainFrame.Navigate(_readNewsPage);
        }
        #endregion

        #region SportNews
        private RelayCommand getSportNews;
        public ICommand GetSportNews
        {
            get
            {
                if (getSportNews == null)
                {
                    getSportNews = new RelayCommand(SportNewsClick);
                }

                return getSportNews;
            }
        }

        private void SportNewsClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            _readNewsPage.DataContext = new ReadNewsPageViewModel(3, _categoryPage);
            main.MainFrame.Navigate(_readNewsPage);
        }
        #endregion

        #region WorldNews
        private RelayCommand getWorldNews;
        public ICommand GetWorldNews
        {
            get
            {
                if (getWorldNews == null)
                {
                    getWorldNews = new RelayCommand(WorldNewsClick);
                }

                return getWorldNews;
            }
        }

        private void WorldNewsClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            _readNewsPage.DataContext = new ReadNewsPageViewModel(2, _categoryPage);
            main.MainFrame.Navigate(_readNewsPage);
        }
        #endregion

        #region NationalNews
        private RelayCommand getNationalNews;
        public ICommand GetNationalNews
        {
            get
            {
                if (getNationalNews == null)
                {
                    getNationalNews = new RelayCommand(NationalNewsClick);
                }

                return getNationalNews;
            }
        }

        private void NationalNewsClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;

            _readNewsPage.DataContext = new ReadNewsPageViewModel(1, _categoryPage);
            main.MainFrame.Navigate(_readNewsPage);
        }
        #endregion

        #region AllNews
        private RelayCommand getAllNews;
        public ICommand GetAllNews
        {
            get
            {
                if (getAllNews == null)
                {
                    getAllNews = new RelayCommand(AllNewsClick);
                }

                return getAllNews;
            }
        }

        private void AllNewsClick(object sender)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            _readNewsPage.DataContext = new ReadNewsPageViewModel(0, _categoryPage);
            main.MainFrame.Navigate(_readNewsPage);
        }
        #endregion

        #region Quit
        private RelayCommand quit;
        public ICommand Quit
        {
            get
            {
                if (quit == null)
                {
                    quit = new RelayCommand(QuitClick);
                }

                return quit;
            }
        }

        private void QuitClick(object sender)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region Subscribe
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
            MainWindow main = Application.Current.MainWindow as MainWindow;
            _subscribePage.DataContext = new SubscribePageViewModel(_categoryPage);
            main.MainFrame.Navigate(_subscribePage);
        }
        #endregion
    }
}
