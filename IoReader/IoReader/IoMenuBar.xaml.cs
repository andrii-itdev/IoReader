using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace IoReader
{
    /// <summary>
    /// Interaction logic for IoMenuBar.xaml
    /// </summary>
    public partial class IoMenuBar : UserControl, INotifyPropertyChanged
    {
        public IoMenuBar()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty RevealConditionProperty = DependencyProperty.Register(
            "RevealCondition", typeof(bool), typeof(IoMenuBar));

        public event PropertyChangedEventHandler PropertyChanged;

        public bool RevealCondition
        {
            get { return (bool)GetValue(RevealConditionProperty); }
            set
            {
                SetValue(RevealConditionProperty, value);
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
