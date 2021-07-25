using System.Collections.ObjectModel;
using System.Windows.Input;
using IoReader.Communication.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels.ContentViewModels
{
    public class BookViewModel : ViewModelBase<BookModel>, IContentViewModel
    { 
        public ObservableCollection<ICommand> BookActionsCommands { get; set; }

        public ICommand SaveBookCommand { get; set; }

        public ICommand AddBookmarkCommand { get; set; }

        public IContentMediator Mediator { get; protected set; }

        public BookViewModel(IContentMediator contentMediator, BookModel bookModel)
        {
            Mediator = contentMediator;
            UnderlyingModel = bookModel;
        }
    }
}