using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using IoReader.Models;
using IoReader.Communication.Mediators;

namespace IoReader.ViewModels.ContentViewModels
{
    public class BookInformationViewModel : ViewModelBase<BookInformationModel>, IContentViewModel
    {

        #region Commands

        public ICommand OpenLibraryCommand { get; set; }

        public ICommand RemoveFromLibraryCommand { get; set; }

        public ICommand ImportBookInformationCommand { get; set; }

        public ICommand ExportBookInformationCommand { get; set; }
        
        public ICommand OpenBookCommand { get; set; }
        
        public ObservableCollection<ICommand> BookInformationActionsCommands { get; set; }

        #endregion

        public string Title
        {
            get => UnderlyingModel.Title;
            set => UnderlyingModel.Title = value;
        }

        public string Author
        {
            get => UnderlyingModel.Author;
            set => UnderlyingModel.Author = value;
        }

        public int Year
        {
            get => UnderlyingModel.Year;
            set => UnderlyingModel.Year = value;
        }

        public string Description
        {
            get => UnderlyingModel.Description;
            set => UnderlyingModel.Description = value;
        }

        public Image Picture { get; set; }
        // Needs changes

        public ObservableCollection<BookmarkViewModel> Bookmarks
        {
            get { 
                return new ObservableCollection<BookmarkViewModel>(
                    UnderlyingModel.Bookmarks.Select(x => new BookmarkViewModel(x))
                ); 
            }
        }

        public IContentMediator Mediator { get; protected set; }

        protected BookInformationViewModel(IContentMediator contentMediator)
        {
            Mediator = contentMediator;
        }
        public BookInformationViewModel(IContentMediator contentMediator, BookInformationModel model) : this(contentMediator)
        {
            this.UnderlyingModel = model;
        }

        public BookInformationViewModel(IContentMediator contentMediator, AddNewBookViewModel fromAddNewBookViewModel) : this(contentMediator)
        { 
            Author = fromAddNewBookViewModel.Author;
            Title = fromAddNewBookViewModel.Title;
            Year = fromAddNewBookViewModel.Year;
        }

    }
}