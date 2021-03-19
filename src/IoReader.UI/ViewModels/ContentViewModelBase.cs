using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace IoReader
{
    public abstract class ContentViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ContentViewModelBase IoButtonTransitionTarget { get; set; }

        public ContentViewModelBase()
        {
            this.IoButtonTransitionTarget = this;
        }

    }
}