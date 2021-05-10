using System.Windows.Input;
using IoReader.Commands;
using IoReader.Mediators;
using IoReader.ViewModels.ContentViewModels;

namespace IoReader.ViewModels
{
    public class WindowContentViewModel : ViewModelBase, IHasContentMediator
    {
        private IContentViewModel _contentView;

        public IContentMediator Mediator { get; protected set; }

        public IContentViewModel LastContentViewModel { get; protected set; }

        public LibraryViewModel LibraryVm { get; protected set; }
        public BookInformationViewModel BookInfoVm { get; protected set; }
        public BookViewModel BookVm { get; protected set; }
        public AddNewBookViewModel AddNewBookViewModel { get; protected set; }

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

            this.LibraryVm = new LibraryViewModel(contentMediator);
            this.BookInfoVm = new BookInformationViewModel(contentMediator);
            this.BookVm = new BookViewModel(contentMediator);
            this.AddNewBookViewModel = new AddNewBookViewModel(contentMediator);

            this.ContentVm = BookVm;
            this.CollapseRevealBookCommand = new RelayCommand(OnCollapseRevealBookExecute);
            this.Mediator.NavigationEvent += MediatorOnNavigate;
            this.Mediator.AddNewBookEvent += MediatorOnAddNewBook;
            this.Mediator.NavigateLastEvent += MediatorOnNavigateLast;
            this.Mediator.NavigateBookEvent += MediatorOnNavigateBook;

            Mediator.Navigate(LibraryVm);
        }

        private void MediatorOnNavigateBook()
        {
            this.Mediator.Navigate(this.BookVm);
        }

        private void MediatorOnNavigateLast()
        {
            this.Mediator.Navigate(this.LastContentViewModel);
        }

        private void MediatorOnAddNewBook(AddNewBookViewModel obj)
        {
            this.LibraryVm.DefaultBookShelfViewModel.AddBook(obj);
        }

        private void MediatorOnNavigate(IContentViewModel contentViewModel)
        {
            if (this.ContentVm is BookViewModel bookViewModel)
            {
                if (contentViewModel is BookViewModel targetBookViewModel)
                {
                    this.BookVm = targetBookViewModel;
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
                    this.BookVm = targetBookViewModel;
                    this.LastContentViewModel = this.ContentVm;
                    this.ContentVm = targetBookViewModel;
                }
                else
                {
                    this.LastContentViewModel = this.ContentVm;
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