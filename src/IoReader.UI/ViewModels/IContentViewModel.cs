using System.ComponentModel;

namespace IoReader.ViewModels
{
    public interface IContentViewModel : INotifyPropertyChanged
    {
        IContentViewModel IoButtonTransitionTarget { get; set; }
    }
}