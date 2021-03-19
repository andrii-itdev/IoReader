using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace IoReader.Models
{
    public class BookModel
    {

        public Stream ContentsStream { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public string Title { get; set; }

        public Image Picture { get; set; }

        public int Description { get; set; }

        public IEnumerable<BookmarkModel> Bookmarks { get; set; }
    }
}