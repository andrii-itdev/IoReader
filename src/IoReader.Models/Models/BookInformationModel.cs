﻿using System.Collections.Generic;

namespace IoReader.Models
{
    public class BookInformationModel : INoBookContentModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public IEnumerable<BookmarkModel> Bookmarks { get; set; }

        public BookshelfModel BookshelfModel { get; set; }

        public BookInformationModel(BookshelfModel bookshelfModel)
        {
            this.BookshelfModel = bookshelfModel;
        }
    }
}
