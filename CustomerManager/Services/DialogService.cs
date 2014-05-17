namespace CustomerManager.Services
{
    using System.Windows;

    public class DialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
