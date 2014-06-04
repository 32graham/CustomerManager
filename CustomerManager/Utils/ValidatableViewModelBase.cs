namespace CustomerManager.Utils
{
    using GalaSoft.MvvmLight;
    using MvvmValidation;
    using System.ComponentModel;

    public class ModelBase : ObservableObject, IDataErrorInfo
    {
        public ModelBase()
        {
            this.Validator = new ValidationHelper();
            this.DataErrorInfoAdapter = new DataErrorInfoAdapter(this.Validator);
        }

        public string Error
        {
            get
            {
                return DataErrorInfoAdapter.Error;
            }
        }

        protected ValidationHelper Validator { get; private set; }

        private DataErrorInfoAdapter DataErrorInfoAdapter { get; set; }

        public string this[string columnName]
        {
            get
            {
                return DataErrorInfoAdapter[columnName];
            }
        }
    }
}
