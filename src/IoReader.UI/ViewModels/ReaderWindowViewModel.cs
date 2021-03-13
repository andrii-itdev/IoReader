using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace IoReader
{
    public class ReaderWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        IoFrameViewModelBase frame;

        #endregion

        #region Properties

        public System.Windows.Input.ICommand ExitCommand
        {
            get;
            set;
        }

        public System.Windows.Input.ICommand MaximizeCommand
        {
            get;
            set;
        }

        public System.Windows.Input.ICommand MinimizeCommand
        {
            get;
            set;
        }

        public IoFrameViewModelBase Frame
        {
            get { return frame; }
            set
            {
                frame = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        public ReaderWindowViewModel()
        {
            this.Frame = new LibraryViewModel();
            this.Frame.CollapseRevealBookCommand.Execute(this.Frame);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}