using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace ChatApp
{
    //takes a hex value and returns a brush
    class StringToBrushConverter : BaseValueConverters<StringToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
