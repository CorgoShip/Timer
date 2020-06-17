using System.Windows;
using Timer.ViewModels;

namespace Timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CountDown : Window
    {
        public CountDown()
        {
            InitializeComponent();
            this.DataContext = new CountDownViewModel(TimePickerViewModel.timeSet);
        }
    }
}
