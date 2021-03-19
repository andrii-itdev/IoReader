using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IoReader.Selectors
{
    public class ViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LibraryTemplate { get; set; }
        public DataTemplate BookInformationTemplate { get; set; }
        public DataTemplate BookContentTemplate { get; set; }

        public ViewTemplateSelector()
        {
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case LibraryViewModel vm:
                    return LibraryTemplate;
                case BookInformationViewModel vm:
                    return BookInformationTemplate;
                case BookViewModel vm:
                    return BookContentTemplate;
                default:
                    return base.SelectTemplate(item, container);
            }
        }
    }
}
