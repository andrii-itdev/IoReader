using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace IoReader
{
    public class ReaderWindowViewModel
    {
        private WindowContentViewModel ioWindow;
        #region Fields

        #endregion

        #region Properties

        public ICommand ExitCommand
        {
            get;
            set;
        }

        public ICommand MaximizeCommand
        {
            get;
            set;
        }

        public ICommand MinimizeCommand
        {
            get;
            set;
        }

        public WindowContentViewModel IoWindow
        {
            get
            {
                return ioWindow;
            }
            set
            {
                ioWindow = value;
            }
        }

        #endregion

        public ReaderWindowViewModel()
        {
            IoWindow = new WindowContentViewModel();
        }
    }
}