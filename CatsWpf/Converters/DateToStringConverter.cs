using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CatsWpf.Converters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date;
            bool isFormatProper =
                 DateTime.TryParseExact(((string)value), "dd/MM/yyyy"
                                        , CultureInfo.CurrentCulture, DateTimeStyles.None
                                        , out date);
            return isFormatProper ? date : DateTime.Now;
        }
    }
}
