using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using IoReader.Commands;
using IoReader.Models;
using IoReader.ViewModels.ContentViewModels;
using IoReader.Communication.Mediators;

namespace IoReader.ViewModels
{
    public class BookShelfViewModel : ViewModelBase<BookshelfModel>, IHasContentMediator
    {
        public ICommand AddBookCommand { get; set; }

        public ICommand RemoveBookCommand { get; set; }

        public ICommand MoveUpTheListCommand { get; set; }

        public ICommand MoveDownTheListCommand { get; set; }

        public ICommand ExportBookshelfCommand { get; set; }

        public ICommand RemoveBookshelfCommand { get; set; }

        public ObservableCollection<BookInformationViewModel> Books
        {
            get
            {
                return new ObservableCollection<BookInformationViewModel>(
                    UnderlyingModel.Books.Select(x => new BookInformationViewModel(this.Mediator, x))
                    );
            }
        }

        public string Title { get; set; }
        public IContentMediator Mediator { get; protected set; }

        public BookShelfViewModel(IContentMediator mediator, BookshelfModel model)
        {
            this.Mediator = mediator;
            this.UnderlyingModel = model;
            this.UnderlyingModel.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                this.OnPropertyChanged(e.PropertyName);
            };
            AddBookCommand = new RelayCommand(OnAddNewBookExecute);
            RemoveBookCommand = new RelayCommand(OnRemoveBookExecute);
        }

        private void OnRemoveBookExecute(object obj)
        {
            if (obj is BookInformationViewModel bookInformation)
            {
                this.Mediator.RemoveBook(bookInformation.UnderlyingModel);
            }
        }

        private void OnAddNewBookExecute(object obj)
        {
            this.Mediator.NavigateAddNewBook(this.UnderlyingModel);
        }
    }
}