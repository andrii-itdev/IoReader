using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using IoReader.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels
{
    public class LibraryViewModel : ViewModelBase, IContentViewModel, IHasContentMediator
    {
        public ObservableCollection<BookShelfViewModel> BookShelves { get; set; }

        public ICommand AddBookShelfCommand { get; set; }

        public ICommand ImportBookShelfCommand { get; set; }

        public ICommand SearchTheLibraryCommand { get; set; }
        
        public ObservableCollection<ICommand> LibraryCommands { get; set; }

        public LibraryModel Library { get; set; }

        public IContentViewModel IoButtonTransitionTarget { get; set; }

        public ContentMediator Mediator { get; protected set; }

        public LibraryViewModel(ContentMediator contentMediator)
        {
            Mediator = contentMediator;

            this.BookShelves = new ObservableCollection<BookShelfViewModel>();
            var bookInfos = new ObservableCollection<BookInformationViewModel>();
            bookInfos.Add(new BookInformationViewModel(Mediator)
            {
                Title = "An Alborado",
                Author = "J. J. Abrams",
                Description = "A cool book about a real city made of diamonds"
            });
            this.BookShelves.Add(
                new BookShelfViewModel(Mediator)
                {
                    Title = "Favorite Fiction",
                    BooksInfos = bookInfos
                }
                );
        }
    }
}