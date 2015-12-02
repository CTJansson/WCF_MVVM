using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UserNewsApp
{
    class NoNavFrame : Frame
    {
        public NoNavFrame()
        {
            this.Navigated += new System.Windows.Navigation.NavigatedEventHandler(NoNavFrame_Navigated);
        }

        void NoNavFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();
        }
    }
}
