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

        void AddNewBook(BookshelfModel onTopOf, BookInformationModel newBookModel);
        void RemoveBook(BookInformationModel bookModel);
        void OpenNewBook(BookModel bookModel);
    }

    public class ContentMediator : IContentMediator
    {
        class ContentStateMachine
        {
            public BookModel BookModel { get; }
            public INoBookContentModel NoBookContent { get; set; }
            public LibraryModel LibraryModel { get; }

            private IContentModel LastModel { get; set; }
            public IContentModel CurrentModel { get; set; }
            public bool IsCurrentModelBook => CurrentModel is BookModel;

            public ContentStateMachine(DataLoader dataLoader)
            {
                BookModel = dataLoader.LoadBook();
                LibraryModel = dataLoader.LoadLibrary();

                NoBookContent = LibraryModel;
                CurrentModel = null;
                LastModel = BookModel;
            }
        }

        private readonly ContentStateMachine _contentStateMachine;

        public event Action<BookModel> BookViewUpdatedEvent;
        public event Action<BookInformationModel> BookInfoViewUpdatedEvent;
        public event Action<LibraryModel> LibraryViewUpdatedEvent;
        public event Func<BookshelfModel, BookInformationModel> AddNewBookViewUpdatedEvent;

        public ContentMediator(DataLoader dataLoader)
        {
            _contentStateMachine = new ContentStateMachine(dataLoader);
        }

        public void NavigateLast()
        {
            if (!NavigateBook())
            {
                switch (_contentStateMachine.NoBookContent)
                {
                    case LibraryModel _:
                        NavigateLibrary();
                        break;
                    default:
                        throw new NotSupportedException($"NavigateLast for entities other than {nameof(LibraryModel)}");
                }
            }
        }

        public bool NavigateBook()
        {
            if (_contentStateMachine.IsCurrentModelBook)
            {
                return false;
            }
            else
            {
                _contentStateMachine.CurrentModel = _contentStateMachine.BookModel;
                BookViewUpdatedEvent?.Invoke(_contentStateMachine.BookModel);
                return true;
            }
        }

        public bool NavigateLibrary()
        {
            if (_contentStateMachine.CurrentModel == _contentStateMachine.LibraryModel)
            {
                return false;
            }
            else
            {
                _contentStateMachine.NoBookContent = _contentStateMachine.LibraryModel;
                _contentStateMachine.CurrentModel = _contentStateMachine.NoBookContent;
                LibraryViewUpdatedEvent?.Invoke(_contentStateMachine.LibraryModel);
                return true;
            }
        }

        public void NavigateAddNewBook(BookshelfModel onTopOfBookshelfModel)
        {
            if (AddNewBookViewUpdatedEvent != null)
            {
                var bookInformation = AddNewBookViewUpdatedEvent.Invoke(onTopOfBookshelfModel);
                _contentStateMachine.NoBookContent = bookInformation;
                _contentStateMachine.CurrentModel = _contentStateMachine.NoBookContent;
            }
        }

        public void AddNewBook(BookshelfModel onTopOf, BookInformationModel newBookModel)
        {
            if (_contentStateMachine.LibraryModel.Bookshelves.Contains(onTopOf))
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
            if (_contentStateMachine.LibraryModel.RemoveBook(bookModel))
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
