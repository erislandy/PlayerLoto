using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace QueryDrawingResultsModule.Converters
{
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = (int?)value;
            return number.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numberString = (string)value;
            int? number;

            if (string.IsNullOrEmpty(numberString))
            {
                number = null;
            }
            else
            {
                try
                {
                    number = int.Parse(numberString);
                }
                catch (Exception)
                {
                    number = null;
                }
                
            }

            return number;
        }
    }
}
