namespace CustomerManager
{
    using System.Windows;

    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CustomerManager.Utils.AutoMapperConfig.Configure();
        }
    }
}
