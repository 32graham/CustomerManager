namespace CustomerManager.Services
{
    using System;
    using System.Windows;

    public class NavigationService : INavigationService
    {
        private System.Windows.Controls.Frame frame;

        public NavigationService()
        {
            this.frame = (Application.Current.MainWindow as CustomerManager.MainWindow).MainFrame;
        }

        public void GoBack()
        {
            frame.GoBack();
        }

        public void NavigateTo(Uri uri, object state = null)
        {
            if (state == null)
            {
                frame.Navigate(uri);
            }
            else
            {
                frame.Navigate(uri, state);
            }
        }
    }
}
