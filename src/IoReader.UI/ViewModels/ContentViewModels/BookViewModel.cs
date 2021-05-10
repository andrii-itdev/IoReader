using System.Collections.ObjectModel;
using System.Windows.Input;
using IoReader.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels.ContentViewModels
{
    public class BookViewModel : ViewModelBase, IContentViewModel, IHasContentMediator
    { 
        public ObservableCollection<ICommand> BookActionsCommands { get; set; }

        public ICommand SaveBookCommand { get; set; }

        public ICommand AddBookmarkCommand { get; set; }

        public BookModel Book { get; set; }

        public IContentMediator Mediator { get; protected set; }

        public BookViewModel(IContentMediator contentMediator)
        {
            Mediator = contentMediator;
        }
    }
}