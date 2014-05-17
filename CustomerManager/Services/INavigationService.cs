namespace CustomerManager.Services
{
    using System;

    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(Uri uri, object state = null);
    }
}
