using PlayerLoto.Services.FilterOperation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace QueryDrawingResultsModule.Converters
{
    public class DrawingStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parammeterType = (DrawingState)value;
            return parammeterType.ToString();
        }

       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueString = (string)value;
            DrawingState parammeter = (DrawingState)Enum.Parse(typeof(DrawingState), valueString);
            return parammeter;
        }

       
    }
}
