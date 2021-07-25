using System;
using System.Runtime.CompilerServices;
using IoReader.Models;
using IoReader.Models.ApplicationData;
using IoReader.Communication;

namespace IoReader.Communication.Mediators
{
    public interface IContentMediator
    {
        event Action<BookModel> BookViewUpdatedEvent;
        event Action<BookInformationModel> BookInfoViewUpdatedEvent;
        event Action<LibraryModel> LibraryViewUpdatedEvent;
        event Func<BookshelfModel, BookInformationModel> AddNewBookViewUpdatedEvent;

        void NavigateLast();
        bool NavigateBook();
        bool NavigateLibrary();
        void NavigateAddNewBook(BookshelfModel onTopOfBookshelfModel);

        void AddNewBook(BookInformationModel addNewBookViewModel);
        void AddNewBook(BookshelfModel onTopOf, BookInformationModel newBookModel);
        void RemoveBook(BookInformationModel bookModel);
        void OpenNewBook(BookModel bookModel);
    }

    public class ContentMediator : IContentMediator
    {
        class ContentStateMachine
        {
            public BookModel BookModel { get; set; }
            public INoBookContentModel NoBookContent { get; set; }
            public LibraryModel LibraryModel { get; set; }

            public IContentModel LastModel { get; set; }
            public IContentModel CurrentModel { get; set; }
            public bool IsCurrentModelBook { get { return CurrentModel is BookModel; } }

            public readonly IContentModel DefaultModel;

            public ContentStateMachine(DataLoader dataLoader)
            {
                BookModel = dataLoader.LoadBook();
                LibraryModel = dataLoader.LoadLibrary();

                NoBookContent = LibraryModel;
                DefaultModel = LibraryModel;
                CurrentModel = null;
                LastModel = BookModel;
            }
        }

        private ContentStateMachine contentStateMachine;

        public event Action<BookModel> BookViewUpdatedEvent;
        public event Action<BookInformationModel> BookInfoViewUpdatedEvent;
        public event Action<LibraryModel> LibraryViewUpdatedEvent;
        public event Func<BookshelfModel, BookInformationModel> AddNewBookViewUpdatedEvent;

        //public event Action<> ContentModelUpdated;

        //public void Navigate(IContentModel contentViewModel)
        //{
        //    NavigationEvent?.Invoke(contentViewModel);
        //}

        public ContentMediator(DataLoader dataLoader)
        {
            contentStateMachine = new ContentStateMachine(dataLoader);
        }

        public void NavigateLast()
        {
            if (!NavigateBook())
            {
                switch (contentStateMachine.NoBookContent)
                {
                    case LibraryModel _:
                        NavigateLibrary();
                        break;
                    default:
                        throw new NotSupportedException($"NavigateLast for entities other than {typeof(LibraryModel).Name}");
                }
            }
        }

        public bool NavigateBook()
        {
            if (contentStateMachine.IsCurrentModelBook)
            {
                return false;
            }
            else
            {
                contentStateMachine.CurrentModel = contentStateMachine.BookModel;
                BookViewUpdatedEvent.Invoke(contentStateMachine.BookModel);
                return true;
            }
        }

        public bool NavigateLibrary()
        {
            if (contentStateMachine.CurrentModel == contentStateMachine.LibraryModel)
            {
                return false;
            }
            else
            {
                contentStateMachine.NoBookContent = contentStateMachine.LibraryModel;
                contentStateMachine.CurrentModel = contentStateMachine.NoBookContent;
                LibraryViewUpdatedEvent?.Invoke(contentStateMachine.LibraryModel);
                return true;
            }
        }

        public void NavigateAddNewBook(BookshelfModel onTopOfBookshelfModel)
        {
            var bookinformation = AddNewBookViewUpdatedEvent.Invoke(onTopOfBookshelfModel);
            contentStateMachine.NoBookContent = bookinformation;
            contentStateMachine.CurrentModel = contentStateMachine.NoBookContent;
        }

        public void AddNewBook(BookInformationModel newBookModel)
        {
            AddNewBook(contentStateMachine.LibraryModel.Default, newBookModel);
        }
        public void AddNewBook(BookshelfModel onTopOf, BookInformationModel newBookModel)
        {
            if (contentStateMachine.LibraryModel.Bookshelves.Contains(onTopOf))
            {
                onTopOf.Add(newBookModel);
                NavigateLibrary();
            }
            else
            {
                throw new ArgumentException($"Bookshelf {onTopOf} does not exist exist in the library.", nameof(onTopOf));
            }
        }

        public void RemoveBook(BookInformationModel bookModel)
        {
            if (contentStateMachine.LibraryModel.RemoveBook(bookModel))
            {
                NavigateLibrary();
            }
        }

        public void OpenNewBook(BookModel bookModel)
        {
            // TODO
        }
    }
}
