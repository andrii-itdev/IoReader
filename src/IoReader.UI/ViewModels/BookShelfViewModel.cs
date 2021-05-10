using System.Collections.ObjectModel;
using System.Windows.Input;
using IoReader.Commands;
using IoReader.Mediators;
using IoReader.Models;
using IoReader.ViewModels.ContentViewModels;

namespace IoReader.ViewModels
{
    public class BookShelfViewModel : ViewModelBase, IHasContentMediator
    {
        public ICommand AddBookCommand { get; set; }

        public ICommand RemoveBookCommand { get; set; }

        public ICommand MoveUpTheListCommand { get; set; }

        public ICommand MoveDownTheListCommand { get; set; }

        public ICommand ExportBookshelfCommand { get; set; }

        public ICommand RemoveBookshelfCommand { get; set; }

        public ObservableCollection<BookInformationViewModel> BooksInfos { get; set; }

        public BookshelfModel Bookshelf { get; set; }

        public string Title { get; set; }
        public IContentMediator Mediator { get; protected set; }

        public BookShelfViewModel(IContentMediator mediator)
        {
            this.Mediator = mediator;
            this.BooksInfos = new ObservableCollection<BookInformationViewModel>();
            AddBookCommand = new RelayCommand(OnAddNewBookExecute);
            RemoveBookCommand = new RelayCommand(OnRemoveBookExecute);
        }

        private void OnRemoveBookExecute(object obj)
        {
            if (obj is BookInformationViewModel bookInformation)
            {
                this.BooksInfos.Remove(bookInformation);
            }
        }

        private void OnAddNewBookExecute(object obj)
        {
            this.Mediator.Navigate(new AddNewBookViewModel(Mediator));
        }

        public void AddBook(BookInformationViewModel bookInformationViewModel)
        {
            this.BooksInfos.Add(bookInformationViewModel);
        }

        public void AddBook(AddNewBookViewModel newBookViewModel)
        {
            AddBook(
                new BookInformationViewModel(Mediator)
                {
                    Author = newBookViewModel.Author,
                    Title = newBookViewModel.Name,
                    Year = newBookViewModel.Year
                    // File Path
                    // Description
                }
                );
        }
    }
}