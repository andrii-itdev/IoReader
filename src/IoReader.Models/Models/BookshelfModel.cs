using System.Collections.Generic;

namespace IoReader.Models
{
    public class BookshelfModel
    {
        public string Title { get; set; }

        public IEnumerable<BookModel> Books { get; set; }
    }
}