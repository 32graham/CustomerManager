namespace CustomerManager.Services
{
    using System.Windows;

    public class NavigationService : INavigationService
    {
        public void GoBack()
        {
            var frame = (Application.Current.MainWindow as CustomerManager.MainWindow).MainFrame;

            frame.GoBack();
        }

        public void NavigateTo(object destination)
        {
            var frame = (Application.Current.MainWindow as CustomerManager.MainWindow).MainFrame;

            frame.Navigate(destination);
        }
    }
}
