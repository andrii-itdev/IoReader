using System.Windows.Input;
using IoReader.Models;

namespace IoReader.ViewModels
{
    public class BookmarkViewModel : ViewModelBase<BookmarkModel>
    {
        public ICommand RemoveBookmarkCommand { get; set; }

        public ICommand GotoCommand { get; set; }
        
        public string Name { get { return UnderlyingModel.Name; } set { UnderlyingModel.Name = Name; OnPropertyChanged(); } }

        public BookmarkViewModel(BookmarkModel model)
        {
            UnderlyingModel = model;
        }
    }
}