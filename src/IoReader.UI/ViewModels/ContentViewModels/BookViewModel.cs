using System.Collections.ObjectModel;
using System.Windows.Input;
using IoReader.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels
{
    public class BookViewModel : ViewModelBase, IContentViewModel, IHasContentMediator
    { 
        public ObservableCollection<ICommand> BookActionsCommands { get; set; }

        public int SaveBookCommand { get; set; }

        public int AddBookmarkCommand { get; set; }

        public BookModel Book { get; set; }

        public IContentViewModel IoButtonTransitionTarget { get; set; }
        public ContentMediator Mediator { get; protected set; }

        public BookViewModel(ContentMediator contentMediator)
        {
            Mediator = contentMediator;
        }
    }
}