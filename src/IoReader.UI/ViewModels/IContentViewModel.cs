using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace IoReader
{
    public interface IContentViewModel : INotifyPropertyChanged
    {
        IContentViewModel IoButtonTransitionTarget { get; set; }
    }
}