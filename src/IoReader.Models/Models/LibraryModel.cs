using System.Collections.Generic;

namespace IoReader.Models
{
    public class LibraryModel
    {
        public IEnumerable<BookshelfModel> Bookshelves { get; set; }
    }
}