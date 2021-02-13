﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IoReader
{
    public class BookViewModel : IoFrameViewModelBase
    {
        public ObservableCollection<ICommand> BookActionsCommands
        {
            get => default;
            set
            {
            }
        }

        public int SaveBookCommand
        {
            get => default;
            set
            {
            }
        }

        public int AddBookmarkCommand
        {
            get => default;
            set
            {
            }
        }

        public BookModel Book
        {
            get => default;
            set
            {
            }
        }
    }
}