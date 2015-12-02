using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserNewsApp.Views;

namespace UserNewsApp.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            CategoryPage categoryPage = new CategoryPage();
            categoryPage.DataContext = new ViewModels.CategoryPageViewModel(categoryPage);
            main.MainFrame.Navigate(categoryPage);
        }
    }
}
