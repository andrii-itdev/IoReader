using System;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using IoReader.ViewModels;
using IoReader.ViewModels.ContentViewModels;

namespace IoReader.Mediators
{
    public delegate void NavigateEventHandler(IContentViewModel contentViewModel);

    public interface IContentMediator
    {
        event Action<IContentViewModel> NavigationEvent;
        event Action NavigateLastEvent;
        event Action NavigateBookEvent;
        event Action<AddNewBookViewModel> AddNewBookEvent;

        void Navigate(IContentViewModel contentViewModel);

        void Navigate(bool last);

        void TriggerAddNewBook(AddNewBookViewModel addNewBookViewModel);
    }

    public class ContentMediator : IContentMediator
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
