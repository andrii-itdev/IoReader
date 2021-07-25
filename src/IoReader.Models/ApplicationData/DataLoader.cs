using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Title = "The Alborado",
                    Author = "J. J. Abrams",
                    Description = "A cool book about a real city made of diamonds"
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
