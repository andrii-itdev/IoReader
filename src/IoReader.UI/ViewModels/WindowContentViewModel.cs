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

        private readonly LibraryViewModel _libraryVm;
        private readonly BookInformationViewModel _bookInfoVm;
        private readonly BookViewModel _bookVm;

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
            this.ContentVm = _libraryVm;
            this.CollapseRevealBookCommand = new RelayCommand(OnCollapseRevealBookExecute);
            this.Mediator.NavigationEvent += MediatorOnNavigate;
            this._bookInfoVm.IoButtonTransitionTarget = _bookVm;
            this._libraryVm.IoButtonTransitionTarget = _bookVm;
            this._bookVm.IoButtonTransitionTarget = _libraryVm;
        }

        private void MediatorOnNavigate(IContentViewModel contentViewModel)
        {
            this.ContentVm = contentViewModel;
        }

        private void OnCollapseRevealBookExecute(object contentViewModel)
        {
            if (contentViewModel is IContentViewModel cvm)
            {
                this.Mediator.Navigate(cvm.IoButtonTransitionTarget);
            }
        }
    }
}