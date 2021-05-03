using System;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using IoReader.ViewModels;
using IoReader.ViewModels.ContentViewModels;

namespace IoReader.Mediators
{
    public delegate void NavigateEventHandler(IContentViewModel contentViewModel);

    public class ContentMediator
    {
        public event Action<IContentViewModel> NavigationEvent;

        public event Action NavigateLastEvent;
        public event Action NavigateBookEvent;

        public event Action<AddNewBookViewModel> AddNewBookEvent;

        public void Navigate(IContentViewModel contentViewModel)
        {
            NavigationEvent?.Invoke(contentViewModel);
        }

        public void Navigate(bool last = true)
        {
            if (last) NavigateLastEvent?.Invoke();
            else NavigateBookEvent?.Invoke();
        }

        public void TriggerAddNewBook(AddNewBookViewModel addNewBookViewModel)
        {
            AddNewBookEvent?.Invoke(addNewBookViewModel);
        }
    }
}
