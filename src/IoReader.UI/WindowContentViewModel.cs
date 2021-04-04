using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace IoReader
{
    public class WindowContentViewModel : INotifyPropertyChanged
    {
        IContentViewModel contentView;

        LibraryViewModel libraryVM = new LibraryViewModel();
        BookInformationViewModel bookInfoVM = new BookInformationViewModel();
        BookViewModel bookVM = new BookViewModel();

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand _collapseRevealBookCommand;
        public ICommand CollapseRevealBookCommand
        {
            get
            {
                return _collapseRevealBookCommand;
            }
            set
            {
                this._collapseRevealBookCommand = value;
            }
        }
        public IContentViewModel ContentVM
        {
            get { return contentView; }
            set
            {
                contentView = value;
                NotifyPropertyChanged();
            }
        }

        public WindowContentViewModel()
        {
            this.ContentVM = libraryVM;
            this.CollapseRevealBookCommand = new RelayCommand(OnCollapseRevealBookExecute);
            this.bookInfoVM.IoButtonTransitionTarget = bookVM;
            this.libraryVM.IoButtonTransitionTarget = bookVM;
            this.bookVM.IoButtonTransitionTarget = libraryVM;
        }

        private void OnCollapseRevealBookExecute(object obj)
        {
            if (obj != null && obj is IContentViewModel cvmb)
            {
                this.ContentVM = cvmb;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}