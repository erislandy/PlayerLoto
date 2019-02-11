using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Services
{
    public class WeekResultManager
    {
        public List<WeekResult> CreateWeekResult(List<DrawingResult> drawingResultListv1)
        {
            var drawingResultList = drawingResultListv1.OrderBy(d => d.Date).ToList();
            List<WeekResult> weekResultList = new List<WeekResult>();

            DateTime initialDate =drawingResultList[0].Date;
            DateTime finalDate = drawingResultList[drawingResultList.Count - 1].Date;

            int day = GetDayOfWeek(initialDate);
            int dayEnd = GetDayOfWeek(finalDate);
            DateTime dateOfSunday = initialDate.AddDays(day * -1);

            CompletteNullsAtTheBegining(drawingResultList, day);
            CompletteNullsAtTheEnd(drawingResultList, dayEnd);


            int amountDays = drawingResultList.Count;
            int amountWeeks = amountDays/7;



            for (int i = 0; i < amountWeeks; i++)
            {
                var drawList = new List<DrawingResult>();
                
                for (int j = 0; j < 7; j++) 
                {
                    drawList.Add(drawingResultList.ElementAt(i*7 + j));
                }

                weekResultList.Add(

                    new WeekResult
                    {
                        DrawType = drawingResultListv1[0].Type,
                        DateOfSunday = dateOfSunday.AddDays(i * 7),
                        Sunday = GetValue(drawList[0]),
                        Monday = GetValue(drawList[1]),
                        Tuesday = GetValue(drawList[2]),
                        Wednesday = GetValue(drawList[3]),
                        Thursday = GetValue(drawList[4]),
                        Friday = GetValue(drawList[5]),
                        Saturday = GetValue(drawList[6]),
                        
                    }
                    );

                
            }
          

            return weekResultList;
        }

        private int? GetValue(DrawingResult drawingResult)
        {
           if(drawingResult == null)
            {
                return null;
            }
            return drawingResult.Pick3;
        }

        public void CompletteNullsAtTheEnd(List<DrawingResult> drawingResultList, int day)
        {
            for (int i = 0; i < 6 - day; i++)
            {
                drawingResultList.Add(null);

            }
        }

        public void CompletteNullsAtTheBegining(List<DrawingResult> drawingResultList, int day)
        {
            for(int i = 0; i < day; i++)
            {
                drawingResultList.Insert(0, null);
                    
            }
        }

        public int GetDayOfWeek(DateTime initialDate)
        {
            string[] weekDays = Enum.GetNames(initialDate.DayOfWeek.GetType());

            return weekDays.ToList().IndexOf(initialDate.DayOfWeek.ToString());

        }

        public bool IsDrawingBelongWeek(DrawingResult drawing, WeekResult weekResult)
        {
            if (drawing.Type != weekResult.DrawType)
            {
                return false;
            }
            DateTime dateSunday = weekResult.DateOfSunday;
            DateTime dateSaturday = dateSunday.AddDays(6);

            int d1 = dateSunday.CompareTo(drawing.Date);
            int d2 = dateSaturday.CompareTo(drawing.Date);
            if (d1 <= 0 && d2 >= 0)
            {
                return true;
            }
            return false;

        }
    }
}
