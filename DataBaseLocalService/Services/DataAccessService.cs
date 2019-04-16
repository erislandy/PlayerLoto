using DataBaseLocalService.Models;
using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Services
{
    public class DataAccessService
    {
        #region Attributes

        private List<DrawingResult> _drawingResultList;
        private List<int> _numberList;

        #endregion
        public DataAccessService()
        {
            _drawingResultList = new List<DrawingResult>()
            {
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,1),
                    Pick3 = 675,
                    Pick4First = 88,
                    Pick4Second = 75,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,1),
                    Pick3 = 694,
                    Pick4First = 34,
                    Pick4Second = 48,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,2),
                    Pick3 = 588,
                    Pick4First = 20,
                    Pick4Second = 82,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,2),
                    Pick3 = 386,
                    Pick4First = 34,
                    Pick4Second = 66,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,3),
                    Pick3 = 712,
                    Pick4First = 16,
                    Pick4Second = 24,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,3),
                    Pick3 = 941,
                    Pick4First = 75,
                    Pick4Second = 16,
                    Type = DrawType.Evening
                },
                 new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,4),
                    Pick3 = 702,
                    Pick4First = 75,
                    Pick4Second = 58,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,4),
                    Pick3 = 403,
                    Pick4First = 19,
                    Pick4Second = 50,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,5),
                    Pick3 = 730,
                    Pick4First = 39,
                    Pick4Second = 6,
                    Type = DrawType.Midday
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019,4,5),
                    Pick3 = 712,
                    Pick4First = 16,
                    Pick4Second = 24,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,5),
                    Pick3 = 68,
                    Pick4First = 45,
                    Pick4Second = 59,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,6),
                    Pick3 = 914,
                    Pick4First = 94,
                    Pick4Second = 3,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,6),
                    Pick3 = 423,
                    Pick4First = 59,
                    Pick4Second = 48,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,7),
                    Pick3 = 310,
                    Pick4First = 54,
                    Pick4Second = 2,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,7),
                    Pick3 = 747,
                    Pick4First = 65,
                    Pick4Second = 64,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,8),
                    Pick3 = 728,
                    Pick4First = 29,
                    Pick4Second = 8,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,8),
                    Pick3 = 805,
                    Pick4First = 92,
                    Pick4Second = 60,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,9),
                    Pick3 = 316,
                    Pick4First = 87,
                    Pick4Second = 56,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,9),
                    Pick3 = 890,
                    Pick4First = 22,
                    Pick4Second = 84,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,10),
                    Pick3 = 591,
                    Pick4First = 35,
                    Pick4Second = 98,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,10),
                    Pick3 = 647,
                    Pick4First = 22,
                    Pick4Second = 4,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,11),
                    Pick3 = 158,
                    Pick4First = 73,
                    Pick4Second = 25,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,11),
                    Pick3 = 178,
                    Pick4First = 29,
                    Pick4Second = 66,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,12),
                    Pick3 = 857,
                    Pick4First = 64,
                    Pick4Second = 51,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,12),
                    Pick3 = 344,
                    Pick4First = 32,
                    Pick4Second = 9,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,13),
                    Pick3 = 783,
                    Pick4First = 44,
                    Pick4Second = 9,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,13),
                    Pick3 = 799,
                    Pick4First = 25,
                    Pick4Second = 97,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,14),
                    Pick3 = 395,
                    Pick4First = 4,
                    Pick4Second = 39,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,4,14),
                    Pick3 = 79,
                    Pick4First = 14,
                    Pick4Second = 62,
                    Type = DrawType.Evening
                },
            };

            _numberList = new List<int>()
            {
                101,301,501,701,101,203,405,605,809,705,430,280,990,870,860,450,320,360,350,390,340,260,200,900,700,660,880,110,140,190
            };

        }

        public List<DrawingResult> GetDrawingResultHistory()
        {
            return _drawingResultList;
        }

        public List<int> GetNumberList()
        {
            return _numberList;
        }


    }
}
