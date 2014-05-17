using GalaSoft.MvvmLight;

namespace CustomerManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string test = "Hello from MainViewModel.cs";

        public MainViewModel()
        {
            var a = 5;
        }

        public string Test
        {
            get
            {
                return this.test;
            }

            set
            {
                Set(() => this.Test, ref this.test, value);
            }
        }
    }
}