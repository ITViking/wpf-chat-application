using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ChatApp
{

    /// <summary>
    /// This base converter allows for using XAML directly
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverters<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {

        private static T converter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
