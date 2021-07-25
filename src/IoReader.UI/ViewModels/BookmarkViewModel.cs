using System.Windows.Input;
using IoReader.Models;

namespace IoReader.ViewModels
{
    public class BookmarkViewModel : ViewModelBase<BookmarkModel>
    {
        public ICommand RemoveBookmarkCommand { get; set; }

        public ICommand GotoCommand { get; set; }

        public string Name
        {
            get => UnderlyingModel.Name;
            set
            {
                UnderlyingModel.Name = value;
                OnPropertyChanged();
            }
        }

        public BookmarkViewModel(BookmarkModel model)
        {
            UnderlyingModel = model;
        }
    }
}