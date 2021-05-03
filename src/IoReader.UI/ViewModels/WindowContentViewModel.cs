using System.Windows.Input;
using IoReader.Commands;
using IoReader.Mediators;
using IoReader.ViewModels.ContentViewModels;

namespace IoReader.ViewModels
{
    public class WindowContentViewModel : ViewModelBase, IHasContentMediator
    {
        private IContentViewModel _contentView;

        public ContentMediator Mediator { get; protected set; }

        private IContentViewModel lastContentViewModel;

        private LibraryViewModel _libraryVm;
        private BookInformationViewModel _bookInfoVm;
        private BookViewModel _bookVm;
        private AddNewBookViewModel _addNewBookViewModel;

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

        public WindowContentViewModel(ContentMediator contentMediator)
        {
            this.Mediator = contentMediator;

            this._libraryVm = new LibraryViewModel(contentMediator);
            this._bookInfoVm = new BookInformationViewModel(contentMediator);
            this._bookVm = new BookViewModel(contentMediator);
            this._addNewBookViewModel = new AddNewBookViewModel(contentMediator);

            this.ContentVm = _bookVm;
            this.CollapseRevealBookCommand = new RelayCommand(OnCollapseRevealBookExecute);
            this.Mediator.NavigationEvent += MediatorOnNavigate;
            this.Mediator.AddNewBookEvent += MediatorOnAddNewBook;
            this.Mediator.NavigateLastEvent += MediatorOnNavigateLast;
            this.Mediator.NavigateBookEvent += MediatorOnNavigateBook;
            Mediator.Navigate(_libraryVm);
        }

        private void MediatorOnNavigateBook()
        {
            this.Mediator.Navigate(this._bookVm);
        }

        private void MediatorOnNavigateLast()
        {
            this.Mediator.Navigate(this.lastContentViewModel);
        }

        private void MediatorOnAddNewBook(AddNewBookViewModel obj)
        {
            this._libraryVm.DefaultBookShelfViewModel.AddBook(obj);
        }

        private void MediatorOnNavigate(IContentViewModel contentViewModel)
        {
            if (this.ContentVm is BookViewModel bookViewModel)
            {
                if (contentViewModel is BookViewModel targetBookViewModel)
                {
                    this._bookVm = targetBookViewModel;
                    this.ContentVm = targetBookViewModel;
                }
                else
                {
                    this.ContentVm = contentViewModel;
                }
            }
            else
            {
                if (contentViewModel is BookViewModel targetBookViewModel)
                {
                    this._bookVm = targetBookViewModel;
                    this.lastContentViewModel = this.ContentVm;
                    this.ContentVm = targetBookViewModel;
                }
                else
                {
                    this.lastContentViewModel = this.ContentVm;
                    this.ContentVm = contentViewModel;
                }
            }
        }

        private void OnCollapseRevealBookExecute(object contentViewModel)
        {
            if (this.ContentVm is BookViewModel bookViewModel)
            {
                this.Mediator.Navigate(true);
            }
            else
            {
                this.Mediator.Navigate(false);
            }
        }
    }
}