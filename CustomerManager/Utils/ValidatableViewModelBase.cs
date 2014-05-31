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
            Validator.ValidateAll();
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

        protected bool SetAndValidate<T>(
            Expression<Func<T>> propertyExpression,
            ref T field,
            T newValue)
        {
            bool wasSet = this.Set(propertyExpression, ref field, newValue);
            this.Validator.Validate(propertyExpression);
            return wasSet;
        }
    }
}
