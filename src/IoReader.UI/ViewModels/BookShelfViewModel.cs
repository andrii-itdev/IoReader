﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using IoReader.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels
{
    public class BookShelfViewModel : ViewModelBase, IHasContentMediator
    {
        public ICommand AddBookCommand { get; set; }

        public ICommand MoveUpTheListCommand { get; set; }

        public ICommand MoveDownTheListCommand { get; set; }

        public ICommand ExportBookshelfCommand { get; set; }

        public ICommand RemoveBookshelfCommand { get; set; }

        public ObservableCollection<BookInformationViewModel> BooksInfos { get; set; }

        public BookshelfModel Bookshelf { get; set; }

        public string Title { get; set; }
        public ContentMediator Mediator { get; protected set; }

        public BookShelfViewModel(ContentMediator mediator)
        {
            this.Mediator = mediator;
        }
    }
}