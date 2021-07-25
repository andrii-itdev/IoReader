using System.Windows.Input;
using IoReader.Commands;
using IoReader.Communication.Mediators;
using IoReader.Mediators;
using IoReader.Models;
using IoReader.Models.ApplicationData;
using IoReader.ViewModels.ContentViewModels;

namespace IoReader.ViewModels
{
    public class WindowContentViewModel : ViewModelBase, IHasContentMediator
    {
        private IContentViewModel _contentView;

        public IContentMediator Mediator { get; protected set; }

        public IContentViewModel LastContentViewModel { get; protected set; }

        public LibraryModel libraryModel { get; set; }
        public BookModel BookModel { get; set; }

        public ICommand CollapseRevealBookCommand { get; set; }

        public IContentViewModel ContentVm
        {
            get => _contentView;
            set
            {
                _contentView = value;
                OnPropertyChanged();
            }
        }

        public WindowContentViewModel(IContentMediator contentMediator)
        {
            this.Mediator = contentMediator;

            this.CollapseRevealBookCommand = new RelayCommand(OnCollapseRevealBookExecute);

            Mediator.LibraryViewUpdatedEvent += Mediator_LibraryViewUpdatedEvent;
            Mediator.BookViewUpdatedEvent += Mediator_BookViewUpdatedEvent;
            Mediator.BookInfoViewUpdatedEvent += Mediator_BookInfoViewUpdatedEvent;
            Mediator.AddNewBookViewUpdatedEvent += Mediator_AddNewBookViewUpdatedEvent;

            Mediator.NavigateLibrary();
        }

        private BookInformationModel Mediator_AddNewBookViewUpdatedEvent(BookshelfModel onTopOfBookshelf)
        {
            var addNewBookVm = new AddNewBookViewModel(this.Mediator, onTopOfBookshelf);
            this.ContentVm = addNewBookVm;
            return addNewBookVm.UnderlyingModel;
        }

        private void Mediator_BookInfoViewUpdatedEvent(BookInformationModel obj)
        {
            this.ContentVm = new BookInformationViewModel(this.Mediator, obj);
        }

        private void Mediator_BookViewUpdatedEvent(BookModel obj)
        {
            this.ContentVm = new BookViewModel(this.Mediator, obj);
        }

        private void Mediator_LibraryViewUpdatedEvent(LibraryModel obj)
        {
            this.ContentVm = new LibraryViewModel(this.Mediator, obj);
        }

        private void OnCollapseRevealBookExecute(object contentViewModel)
        {
            this.Mediator.NavigateLast();
        }
    }
}