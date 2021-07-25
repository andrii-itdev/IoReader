using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IoReader.Commands;
using IoReader.Communication.Mediators;
using IoReader.Models;

namespace IoReader.ViewModels.ContentViewModels
{
    public class AddNewBookViewModel : ViewModelBase<BookInformationModel>, IContentViewModel
    {
        public IContentMediator Mediator { get; protected set; }

        public string Title { get { return this.UnderlyingModel.Title; } set { this.UnderlyingModel.Title = value; OnPropertyChanged(); } }
        public string Author { get { return this.UnderlyingModel.Author; } set { this.UnderlyingModel.Author = value; OnPropertyChanged(); } }
        public int Year { get { return this.UnderlyingModel.Year; } set { this.UnderlyingModel.Year = value; OnPropertyChanged(); } }
        public string FilePath { get; set; } // Requires changes

        public ICommand SaveCommand { get; set; }

        public AddNewBookViewModel(IContentMediator contentMediator, BookshelfModel onTopOfbookshelfModel)
        {
            this.Mediator = contentMediator;
            this.UnderlyingModel = new BookInformationModel(onTopOfbookshelfModel);
            SaveCommand = new RelayCommand<BookshelfModel>(OnSaveNewBookExecute);
        }

        private void OnSaveNewBookExecute(BookshelfModel bookshelfWhere)
        {
            this.Mediator.AddNewBook(bookshelfWhere, this.UnderlyingModel);
        }
    }
}
