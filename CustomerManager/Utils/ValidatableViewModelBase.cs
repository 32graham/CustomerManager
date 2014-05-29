using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmLight = GalaSoft.MvvmLight;
using MvvmValidation;

namespace CustomerManager.Utils
{
    public class ValidatableViewModelBase : MvvmLight.ViewModelBase, IDataErrorInfo
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
