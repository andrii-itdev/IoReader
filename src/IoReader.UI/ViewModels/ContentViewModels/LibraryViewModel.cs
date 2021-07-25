using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using IoReader.Models;
using IoReader.Communication.Mediators;

namespace IoReader.ViewModels.ContentViewModels
{
    public class LibraryViewModel : ViewModelBase<LibraryModel>, IContentViewModel
    {
        public ObservableCollection<BookShelfViewModel> BookShelves
        {
            get
            {
                return new ObservableCollection<BookShelfViewModel>(
                    this.UnderlyingModel.Bookshelves.Select(x => new BookShelfViewModel(this.Mediator, x))
                    );
            } 
        }

        public ICommand AddBookShelfCommand { get; set; }

        public ICommand ImportBookShelfCommand { get; set; }

        public ICommand SearchTheLibraryCommand { get; set; }
        
        public ObservableCollection<ICommand> LibraryCommands { get; set; }


        public IContentMediator Mediator { get; protected set; }

        public LibraryViewModel(IContentMediator contentMediator, LibraryModel model)
        {
            Mediator = contentMediator;

            this.UnderlyingModel = model;
        }
    }
}