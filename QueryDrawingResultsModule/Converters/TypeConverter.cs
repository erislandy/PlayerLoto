
using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace QueryDrawingResultsModule.Converters
{
    public class TypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (DrawType)value;
            if (type == DrawType.Evening)
            {
                return "ic_luna.png";
            }
            if (type == DrawType.Midday)
            {
                return "ic_sol.png";
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
