using System.Windows.Input;
using IoReader.Models;

namespace IoReader.ViewModels
{
    public class BookmarkViewModel : ViewModelBase
    {
        public BookmarkModel BookmarkModel { get; set; }
        public ICommand RemoveBookmarkCommand { get; set; }

        public ICommand GotoCommand { get; set; }
        
        public string Name { get; set; }
    }
}