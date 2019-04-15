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

        #endregion
        public DataAccessService()
        {
            _drawingResultList = new List<DrawingResult>()
            {
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,1),
                    Pick3 = 675,
                    Pick4First = 88,
                    Pick4Second = 75,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,1),
                    Pick3 = 694,
                    Pick4First = 34,
                    Pick4Second = 48,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,2),
                    Pick3 = 588,
                    Pick4First = 20,
                    Pick4Second = 82,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,2),
                    Pick3 = 386,
                    Pick4First = 34,
                    Pick4Second = 66,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,3),
                    Pick3 = 712,
                    Pick4First = 16,
                    Pick4Second = 24,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,3),
                    Pick3 = 941,
                    Pick4First = 75,
                    Pick4Second = 16,
                    Type = DrawType.Evening
                },
                 new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,1),
                    Pick3 = 694,
                    Pick4First = 34,
                    Pick4Second = 48,
                    Type = DrawType.Evening
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,2),
                    Pick3 = 588,
                    Pick4First = 20,
                    Pick4Second = 82,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,2),
                    Pick3 = 386,
                    Pick4First = 34,
                    Pick4Second = 66,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019,1,3),
                    Pick3 = 712,
                    Pick4First = 16,
                    Pick4Second = 24,
                    Type = DrawType.Midday
                },
                new DrawingResultLocal()
                {
                    Date = new DateTime(2019,1,3),
                    Pick3 = 941,
                    Pick4First = 75,
                    Pick4Second = 16,
                    Type = DrawType.Evening
                }
            };

        }

        public List<DrawingResult> GetDrawingResultHistory()
        {
            return _drawingResultList;
        }

       
    }
}
