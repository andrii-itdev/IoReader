using System.Windows.Input;
using IoReader.Mediators;

namespace IoReader.ViewModels
{
    public class ReaderWindowViewModel : ViewModelBase, IHasContentMediator
    {
        #region Properties

        public ICommand ExitCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand MinimizeCommand { get; set; }

        public WindowContentViewModel IoWindow { get; set; }

        public IContentMediator Mediator { get; protected set; }

        #endregion

        public ReaderWindowViewModel(ContentMediator contentMediator)
        {
            IoWindow = new WindowContentViewModel(contentMediator);
            Mediator = contentMediator;
        }
    }
}