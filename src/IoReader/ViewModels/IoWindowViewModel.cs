using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IoReader
{
    public class IoFrameViewModelBase : INotifyPropertyChanged
    {
        public ICommand IoCommand
        {
            get => default;
            set
            {
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}