using System;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using IoReader.ViewModels;

namespace IoReader.Mediators
{
    public delegate void NavigateEventHandler(IContentViewModel contentViewModel);

    public class ContentMediator
    {
        public event Action<IContentViewModel> NavigationEvent;

        public void Navigate(IContentViewModel contentViewModel)
        {
            NavigationEvent?.Invoke(contentViewModel);
        }
    }
}
