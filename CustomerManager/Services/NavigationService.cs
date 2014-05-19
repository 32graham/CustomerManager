namespace CustomerManager.Services
{
    using System.Windows;

    public class NavigationService : INavigationService
    {
        private System.Windows.Controls.Frame frame
        {
            get
            {
                return (Application.Current.MainWindow as CustomerManager.MainWindow).MainFrame;
            }
        }

        public void GoBack()
        {
            this.frame.GoBack();
        }

        public void NavigateTo(object destination)
        {
            this.frame.Navigate(destination);
        }
    }
}
