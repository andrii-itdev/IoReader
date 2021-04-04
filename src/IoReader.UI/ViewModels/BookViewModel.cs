using IoReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace IoReader
{
    public class BookViewModel : ViewModelBase, IContentViewModel
    {
        public ObservableCollection<ICommand> BookActionsCommands
        {
            get => default;
            set
            {
            }
        }

        public int SaveBookCommand
        {
            get => default;
            set
            {
            }
        }

        public int AddBookmarkCommand
        {
            get => default;
            set
            {
            }
        }

        public BookModel Book
        {
            get => default;
            set
            {
            }
        }

        public IContentViewModel IoButtonTransitionTarget { get; set; }
    }
}