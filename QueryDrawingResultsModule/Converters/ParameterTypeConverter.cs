using PlayerLoto.Services.FilterOperation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace QueryDrawingResultsModule.Converters
{
    public class ParameterTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parammeterType = (ParameterType)value;
            return parammeterType.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueString = (string)value;
            ParameterType parammeter = (ParameterType) Enum.Parse(typeof(ParameterType), valueString);
            return parammeter;
        }
    }
}
