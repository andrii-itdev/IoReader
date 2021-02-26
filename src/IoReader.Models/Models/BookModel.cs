using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace IoReader
{
    public class BookModel
    {

        public Stream ContentsStream
        {
            get => default;
            set
            {
            }
        }

        public string Author
        {
            get => default;
            set
            {
            }
        }

        public int Year
        {
            get => default;
            set
            {
            }
        }

        public string Title
        {
            get => default;
            set
            {
            }
        }

        public Image Picture
        {
            get => default;
            set
            {
            }
        }

        public int Description
        {
            get => default;
            set
            {
            }
        }

        public IEnumerable<BookmarkModel> Bookmarks
        {
            get => default;
            set
            {
            }
        }
    }
}