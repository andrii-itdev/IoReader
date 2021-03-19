using System.Windows.Input;

namespace IoReader.ViewModels
{
    public class ReaderWindowViewModel : ViewModelBase
    {
        #region Properties

        public ICommand ExitCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand MinimizeCommand { get; set; }

        public WindowContentViewModel IoWindow { get; set; }

        #endregion

        public ReaderWindowViewModel()
        {
            IoWindow = new WindowContentViewModel();
        }
    }
}