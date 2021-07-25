using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IoReader.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public abstract class ViewModelBase<T> : ViewModelBase
    {
        public T UnderlyingModel { get; protected set; }
    }
}
