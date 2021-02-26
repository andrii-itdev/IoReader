using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace IoReader
{
    public class BookInformationViewModel : IoFrameViewModelBase
    {
        public ICommand OpenLibraryCommand
        {
            get => default;
            set
            {
            }
        }

        public ICommand RemoveFromLibraryCommand
        {
            get => default;
            set
            {
            }
        }

        public ICommand ImportBookInformationCommand
        {
            get => default;
            set
            {
            }
        }

        public ICommand ExportBookInformationCommand
        {
            get => default;
            set
            {
            }
        }

        public ObservableCollection<ICommand> BookInformationActionsCommands
        {
            get => default;
            set
            {
            }
        }

        public ICommand OpenBookCommand
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

        public string Author
        {
            get => default;
            set
            {
            }
        }

        public int Year
        {
            get => default;
            set
            {
            }
        }

        public int Description
        {
            get => default;
            set
            {
            }
        }

        public System.Windows.Controls.Image Picture
        {
            get => default;
            set
            {
            }
        }

        public ObservableCollection<BookmarkViewModel> Bookmarks
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

        public override void OnCollapseRevealBookExecute(object frameObj)
        {
            if (frameObj is Frame frame)
            {
                frame.Navigate(new Uri("Views/BookInformationPage.xaml"), UriKind.Relative);
            }
        }
    }
}