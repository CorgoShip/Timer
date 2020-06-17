using System.Windows;
using Timer.ViewModels;

namespace Timer.Views
{
    /// <summary>
    /// Interaction logic for CounterSet.xaml
    /// </summary>
    public partial class CounterSet : Window
    {
        public CounterSet()
        {
            InitializeComponent();
            this.DataContext = new TimePickerViewModel();
        }        
    }
}
