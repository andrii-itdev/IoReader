using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoReader.Mediators;

namespace IoReader.ViewModels.ContentViewModels
{
    public class AddNewBookViewModel : ViewModelBase, IContentViewModel, IHasContentMediator
    {
        public IContentViewModel IoButtonTransitionTarget { get; set; }
        public ContentMediator Mediator { get; protected set; }

        public AddNewBookViewModel(ContentMediator contentMediator)
        {
            this.Mediator = contentMediator;
        }
    }
}
