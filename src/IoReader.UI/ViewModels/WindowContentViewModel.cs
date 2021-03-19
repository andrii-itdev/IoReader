using System.Windows.Input;
using IoReader.Commands;

namespace IoReader.ViewModels
{
    public class WindowContentViewModel : ViewModelBase
    {
        private IContentViewModel _contentView;

        private readonly LibraryViewModel _libraryVm = new LibraryViewModel();
        private readonly BookInformationViewModel _bookInfoVm = new BookInformationViewModel();
        private readonly BookViewModel _bookVm = new BookViewModel();

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

        public WindowContentViewModel()
        {
            this.ContentVm = _libraryVm;
            this.CollapseRevealBookCommand = new RelayCommand(OnCollapseRevealBookExecute);
            this._bookInfoVm.IoButtonTransitionTarget = _bookVm;
            this._libraryVm.IoButtonTransitionTarget = _bookVm;
            this._bookVm.IoButtonTransitionTarget = _libraryVm;
        }

        private void OnCollapseRevealBookExecute(object obj)
        {
            if (obj is IContentViewModel cvmb)
            {
                this.ContentVm = cvmb;
            }
        }
    }
}