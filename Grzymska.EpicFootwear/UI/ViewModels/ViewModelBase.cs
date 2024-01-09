using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grzymska.EpicFootwear.UI.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public bool HasErrors => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
