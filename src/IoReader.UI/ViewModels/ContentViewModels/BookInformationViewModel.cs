using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using IoReader.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels.ContentViewModels
{
    public class BookInformationViewModel : ViewModelBase, IContentViewModel, IEquatable<BookInformationViewModel>
    {
        public ICommand OpenLibraryCommand { get; set; }

        public ICommand RemoveFromLibraryCommand { get; set; }

        public ICommand ImportBookInformationCommand { get; set; }

        public ICommand ExportBookInformationCommand { get; set; }
        
        public ICommand OpenBookCommand { get; set; }
        
        public ObservableCollection<ICommand> BookInformationActionsCommands { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public Image Picture { get; set; }

        public ObservableCollection<BookmarkViewModel> Bookmarks { get; set; }

        public BookModel Book { get; set; }


        public IContentMediator Mediator { get; protected set; }

        public BookInformationViewModel(IContentMediator contentMediator)
        {
            Mediator = contentMediator;
        }

        public BookInformationViewModel(IContentMediator contentMediator, AddNewBookViewModel fromAddNewBookViewModel) : this(contentMediator)
        { 
            Author = fromAddNewBookViewModel.Author;
            Title = fromAddNewBookViewModel.Name;
            Year = fromAddNewBookViewModel.Year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BookInformationViewModel) obj);
        }

        public bool Equals(BookInformationViewModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Title == other.Title && Author == other.Author && Year == other.Year && Description == other.Description && Equals(Picture, other.Picture) && Equals(Bookmarks, other.Bookmarks);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Author != null ? Author.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Year;
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Picture != null ? Picture.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Bookmarks != null ? Bookmarks.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}