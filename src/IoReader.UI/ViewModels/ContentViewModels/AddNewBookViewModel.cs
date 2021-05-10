using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IoReader.Commands;
using IoReader.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels.ContentViewModels
{
    public class AddNewBookViewModel : ViewModelBase, IContentViewModel, IHasContentMediator
    {
        public IContentMediator Mediator { get; protected set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string FilePath { get; set; }

        public ICommand SaveCommand { get; set; }

        public AddNewBookViewModel(IContentMediator contentMediator)
        {
            this.Mediator = contentMediator;
            SaveCommand = new RelayCommand(OnSaveNewBookExecute);
        }

        private void OnSaveNewBookExecute(object obj)
        {
            this.Mediator.TriggerAddNewBook(this);
            this.Mediator.Navigate(true);
        }
    }
}
