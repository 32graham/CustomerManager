namespace CustomerManager.Utils
{
    using MvvmValidation;
    using System.ComponentModel;
    using GalaSoft.MvvmLight;
    using System.Linq.Expressions;
    using System;

    public class ValidatableViewModelBase : ViewModelBase, IDataErrorInfo
    {
        public ValidatableViewModelBase()
        {
            this.Validator = new ValidationHelper();
            this.DataErrorInfoAdapter = new DataErrorInfoAdapter(Validator);
        }

        protected ValidationHelper Validator { get; private set; }

        private DataErrorInfoAdapter DataErrorInfoAdapter { get; set; }

        public string this[string columnName]
        {
            get { return DataErrorInfoAdapter[columnName]; }
        }

        public string Error
        {
            get { return DataErrorInfoAdapter.Error; }
        }
    }
}
