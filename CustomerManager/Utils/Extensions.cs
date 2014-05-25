namespace CustomerManager.Utils
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}
