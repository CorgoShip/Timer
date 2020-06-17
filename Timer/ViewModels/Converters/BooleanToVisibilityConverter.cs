using System;
using System.Globalization;
using System.Windows;

namespace Timer.ViewModels.Converters
{
    class BooleanToVisibilityConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Boolean && (bool)value)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility && ((Visibility)value == Visibility.Visible))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
