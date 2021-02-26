using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace IoReader
{
    public abstract class IoFrameViewModelBase : INotifyPropertyChanged
    {
        private ICommand _collapseRevealBookCommand;
        public ICommand CollapseRevealBookCommand
        {
            get {
                return _collapseRevealBookCommand;
            }
            set
            {
                this._collapseRevealBookCommand = value;
                IEnumerable<int> lst = new List<int>();
            }
        }

        public IoFrameViewModelBase()
        {
            this.CollapseRevealBookCommand = new RelayCommand(OnCollapseRevealExecute);
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnCollapseRevealExecute(Object obj) => OnCollapseRevealBookExecute(obj);
        
        public abstract void OnCollapseRevealBookExecute(object frame);
    }
}