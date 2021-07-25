using System.Collections.Generic;
using System.ComponentModel;

namespace IoReader.Models
{
    public class BookshelfModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }

        public List<BookInformationModel> Books { get; set; }

        public BookshelfModel()
        {
            Books = new List<BookInformationModel>();
        }

        public void Add(BookInformationModel bookInformationModel)
        {
            this.Books.Add(bookInformationModel);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Books)));
        }

        public bool Remove(BookInformationModel bookInformationModel)
        {
            var removed = this.Books.Remove(bookInformationModel);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Books)));
            return removed;
        }

        public override bool Equals(object obj)
        {
            return obj is BookshelfModel model &&
                   Title == model.Title &&
                   EqualityComparer<List<BookInformationModel>>.Default.Equals(Books, model.Books);
        }

        public override int GetHashCode()
        {
            int hashCode = -206534718;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BookInformationModel>>.Default.GetHashCode(Books);
            return hashCode;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}