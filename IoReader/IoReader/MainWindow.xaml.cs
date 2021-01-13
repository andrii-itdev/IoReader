using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IoReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICommand _maximizeWindowCommand;
        private ICommand _minimizeWindowCommand;
        private ICommand _normlizeWindowCommand;
        private ICommand _exitApplicationCommand;
        private ICommand _dragMoveCommand;

        public MainWindow()
        {
            InitializeComponent();

            _maximizeWindowCommand = new RelayCommand(OnMaximizeWindowExecute);
            _minimizeWindowCommand = new RelayCommand(OnMinimizeWindowExecute);
            _normlizeWindowCommand = new RelayCommand(OnNormlizeWindowExecute);
            _exitApplicationCommand = new RelayCommand(OnExitApplicationExecute);
            _dragMoveCommand = new RelayCommand(OnDragMoveExecute);
        }


        public ICommand MaximizeWindowCommand
        {
            get { return _maximizeWindowCommand; }
        }
        public ICommand MinimizeWindowCommand
        {
            get { return _minimizeWindowCommand; }
        }
        public ICommand NormalizeWindowCommand
        {
            get { return _normlizeWindowCommand; }
        }
        public  ICommand ExitApplicationCommand
        {
            get { return _exitApplicationCommand; }
        }
        public ICommand DragMoveCommand
        {
            get { return _dragMoveCommand; }
        }



        private void OnMaximizeWindowExecute(object parameter)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else NormalizeWindowCommand.Execute(parameter);
            MenuBar.RevealCondition = true;
        }

        private void OnMinimizeWindowExecute(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OnNormlizeWindowExecute(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void OnExitApplicationExecute(object parameter)
        {
            Application.Current.Shutdown();
        }

        private void OnDragMoveExecute(object parameter)
        {
            //if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            //    NormalizeWindowCommand.Execute(parameter);

            DragMove();
        }

    }
}
