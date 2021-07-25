using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using IoReader.Communication.Mediators;
using IoReader.Models.ApplicationData;
using IoReader.ViewModels;

namespace IoReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataLoader dataLoader = new DataLoader();
            ContentMediator contentMediator = new ContentMediator(dataLoader);
            DataContext = new ReaderWindowViewModel(contentMediator);
        }
    }
}
