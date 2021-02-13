using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IoReader
{
    public class LibraryViewModel : IoFrameViewModelBase
    {
        public IEnumerable<BookShelfViewModel> BookShelves
        {
            get => default;
            set
            {
            }
        }

        public System.Windows.Input.ICommand AddBookShelfCommand
        {
            get => default;
            set
            {
            }
        }

        public System.Windows.Input.ICommand ImportBookShelfCommand
        {
            get => default;
            set
            {
            }
        }

        public ObservableCollection<ICommand> LibraryCommands
        {
            get => default;
            set
            {
            }
        }

        public ICommand SearchTheLibraryCommand
        {
            get => default;
            set
            {
            }
        }

        public LibraryModel Library
        {
            get => default;
            set
            {
            }
        }
    }
}