using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using IoReader.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels
{
    public class BookInformationViewModel : ViewModelBase, IContentViewModel, IHasContentMediator
    {
        public ICommand OpenLibraryCommand { get; set; }

        public ICommand RemoveFromLibraryCommand { get; set; }

        public ICommand ImportBookInformationCommand { get; set; }

        public ICommand ExportBookInformationCommand { get; set; }
        
        public ICommand OpenBookCommand { get; set; }
        
        public ObservableCollection<ICommand> BookInformationActionsCommands { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int Description { get; set; }

        public Image Picture { get; set; }

        public ObservableCollection<BookmarkViewModel> Bookmarks { get; set; }

        public BookModel Book { get; set; }

        public IContentViewModel IoButtonTransitionTarget { get; set; }

        public ContentMediator Mediator { get; protected set; }

        public BookInformationViewModel(ContentMediator contentMediator)
        {
            Mediator = contentMediator;
        }
    }
}