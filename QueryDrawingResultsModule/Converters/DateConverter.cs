using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace QueryDrawingResultsModule.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            string mondth = Enum.GetName(typeof(Mondths), date.Month - 1);
            int day = date.Day;
            int year = date.Year;
            return string.Format($"{mondth} {day}, {year}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public enum Mondths
        {
            Ene,Feb, Mar, Abr, May, Jun, Jul, Ago,
            Sep, Oct, Nov, Dic 
        }
    }
}
