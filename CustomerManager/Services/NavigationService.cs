namespace CustomerManager.Services
{
    using System.Windows;

    public class NavigationService : INavigationService
    {
        private System.Windows.Controls.Frame Frame
        {
            get
            {
                return (Application.Current.MainWindow as CustomerManager.MainWindow).MainFrame;
            }
        }

        public void GoBack()
        {
            this.Frame.GoBack();
        }

        public void NavigateTo(object destination)
        {
            this.Frame.Navigate(destination);
        }
    }
}
