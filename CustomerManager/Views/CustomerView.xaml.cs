namespace CustomerManager.Views
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class CustomerView : Page
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("./Views/Test.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri, "state passed from CustomerView.xaml");
        }
    }
}