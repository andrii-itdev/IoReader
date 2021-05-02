using System.Windows;
using System.Windows.Controls;
using IoReader.ViewModels.ContentViewModels;

namespace IoReader.Selectors
{
    public class ViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LibraryTemplate { get; set; }
        public DataTemplate BookInformationTemplate { get; set; }
        public DataTemplate BookContentTemplate { get; set; }
        public DataTemplate AddNewBookTemplate { get; set; }

        public ViewTemplateSelector()
        {
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case LibraryViewModel _:
                    return LibraryTemplate;
                case BookInformationViewModel _:
                    return BookInformationTemplate;
                case BookViewModel _:
                    return BookContentTemplate;
                case AddNewBookViewModel _:
                    return AddNewBookTemplate;
                default:
                    return base.SelectTemplate(item, container);
            }
        }
    }
}
