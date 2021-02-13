using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IoReader
{
    public class BookShelfViewModel : INotifyPropertyChanged
    {
        public System.Windows.Input.ICommand AddBookCommand
        {
            get => default;
            set
            {
            }
        }

        public System.Windows.Input.ICommand MoveUpTheListCommand
        {
            get => default;
            set
            {
            }
        }

        public System.Windows.Input.ICommand MoveDownTheListCommand
        {
            get => default;
            set
            {
            }
        }

        public System.Windows.Input.ICommand ExportBookshelfCommand
        {
            get => default;
            set
            {
            }
        }

        public System.Windows.Input.ICommand RemoveBookshelfCommand
        {
            get => default;
            set
            {
            }
        }

        public ObservableCollection<BookInformationViewModel> BooksInfos
        {
            get => default;
            set
            {
            }
        }

        public BookShelfModel Bookshelf
        {
            get => default;
            set
            {
            }
        }

        public string Title
        {
            get => default;
            set
            {
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}