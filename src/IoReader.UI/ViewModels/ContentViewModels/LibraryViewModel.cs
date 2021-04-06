using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using IoReader.Models;

namespace IoReader.ViewModels
{
    public class LibraryViewModel : ViewModelBase, IContentViewModel
    {
        public IEnumerable<BookShelfViewModel> BookShelves { get; set; }

        public ICommand AddBookShelfCommand { get; set; }

        public ICommand ImportBookShelfCommand { get; set; }

        public ICommand SearchTheLibraryCommand { get; set; }
        
        public ObservableCollection<ICommand> LibraryCommands { get; set; }

        public LibraryModel Library { get; set; }

        public IContentViewModel IoButtonTransitionTarget { get; set; }
    }
}