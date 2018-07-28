using System;
using System.Globalization;
using System.Windows.Data;

namespace Fundacao.ViewModels.Converters
{
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return Math.Ceiling((double)value / 5) * 5;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
