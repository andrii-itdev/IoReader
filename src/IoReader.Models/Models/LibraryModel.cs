using System.Collections.Generic;

namespace IoReader.Models
{
    public class LibraryModel : INoBookContentModel
    {
        public List<BookshelfModel> Bookshelves { get; set; }

        public BookshelfModel Default { get; protected set; }

        public LibraryModel(BookshelfModel defaultBookshelf)
        {
            Bookshelves = new List<BookshelfModel>();
            Default = defaultBookshelf;
            Bookshelves.Add(defaultBookshelf);
        }

        public bool RemoveBook(BookInformationModel book)
        {
            foreach (BookshelfModel bookshelf in Bookshelves)
            {
                if (bookshelf.Remove(book)) return true;
            }
            return false;
        }
    }
}