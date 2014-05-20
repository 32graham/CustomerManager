namespace CustomerManager.Services
{
    using System;

    public interface INavigationService
    {
        void GoBack();

        void NavigateTo(object destination);
    }
}
