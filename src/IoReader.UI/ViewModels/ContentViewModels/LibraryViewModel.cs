﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using IoReader.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels.ContentViewModels
{
    public class LibraryViewModel : ViewModelBase, IContentViewModel
    {
        public ObservableCollection<BookShelfViewModel> BookShelves { get; set; }

        public BookShelfViewModel DefaultBookShelfViewModel { get; set; }

        public ICommand AddBookShelfCommand { get; set; }

        public ICommand ImportBookShelfCommand { get; set; }

        public ICommand SearchTheLibraryCommand { get; set; }
        
        public ObservableCollection<ICommand> LibraryCommands { get; set; }

        public LibraryModel Library { get; set; }

        public IContentMediator Mediator { get; protected set; }

        public LibraryViewModel(IContentMediator contentMediator)
        {
            Mediator = contentMediator;

            this.BookShelves = new ObservableCollection<BookShelfViewModel>();

            this.DefaultBookShelfViewModel = new BookShelfViewModel(Mediator)
            {
                Title = "Default"
            };
            this.BookShelves.Add(DefaultBookShelfViewModel);

            // Just a test
            var bookInfos = new ObservableCollection<BookInformationViewModel>();
            DefaultBookShelfViewModel.AddBook(
                new BookInformationViewModel(Mediator)
                {
                    Title = "The Alborado",
                    Author = "J. J. Abrams",
                    Description = "A cool book about a real city made of diamonds"
                });
        }

        public bool Has(BookInformationViewModel bookInformationViewModel)
        {
            foreach (BookShelfViewModel bookShelf in BookShelves)
            {
                if (bookShelf.Has(bookInformationViewModel)) return true;
            }

            return false;
        }
    }
}