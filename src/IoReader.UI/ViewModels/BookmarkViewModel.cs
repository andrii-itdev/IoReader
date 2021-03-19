using System.Windows.Input;

namespace IoReader.ViewModels
{
    public class BookmarkViewModel : ViewModelBase
    {
        public ICommand RemoveBookmarkCommand { get; set; }

        public ICommand GotoCommand { get; set; }
        
        public string Name { get; set; }
    }
}