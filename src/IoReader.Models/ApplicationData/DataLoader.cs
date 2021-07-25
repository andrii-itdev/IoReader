using System;

namespace IoReader.Models.ApplicationData
{
    public class DataLoader
    {
        public LibraryModel LoadLibrary()
        {
            var defaultBookshelf = new BookshelfModel()
            {
                Title = "Default"
            };

            // Just a test
            defaultBookshelf.Add(
                new BookInformationModel(defaultBookshelf)
                {
                    Title = "Chronicles Of The Basilisk",
                    Author = "Ariana Simand",
                    Description = "Adventure book"
                });

            return new LibraryModel(defaultBookshelf);
        }

        public BookModel LoadBook()
        {
            BookModel bookModel = null;
            try
            {
                // Try Load last opened book
                bookModel = new BookModel();
            }
            catch (Exception)
            {
            }
            return bookModel;
        }
    }
}
