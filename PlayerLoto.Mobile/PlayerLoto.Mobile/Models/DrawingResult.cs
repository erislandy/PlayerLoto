
using System;


namespace PlayerLoto.Mobile.Models
{
    public class DrawingResult
    {
       
        public DateTime Date { get; set; }

       
        public DrawType Type { get; set; }


        public int Pick3 { get; set; }

        public int Pick4First { get; set; }

         public int Pick4Second { get; set; }
    }

    public enum DrawType
    {
        Midday, Evening
    }
}
