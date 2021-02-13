using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IoReader
{
    public class BookmarkViewModel : INotifyPropertyChanged
    {
        public ICommand RemoveBookmarkCommand
        {
            get => default;
            set
            {
            }
        }

        public string Name
        {
            get => default;
            set
            {
            }
        }

        public ICommand GotoCommand
        {
            get => default;
            set
            {
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}