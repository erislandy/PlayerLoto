using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerLoto.Domain;
using PlayerLoto.Services;

namespace PlayerLoto.ServiceTest
{
    [TestClass]
    public class WeekResultFixure
    {
        WeekResult weekResult;
        WeekResultManager manager;
        [TestInitialize]
        public void Setup()
        {
            weekResult = new WeekResult()
            {
                DateOfSunday = new DateTime(2019, 1, 6),
                DrawType = DrawType.Evening,
                Sunday = 855,
                Monday = 53,
                Tuesday = 119,
                Wednesday = 220,
                Thursday = 8,
                Friday = 786,
                Saturday = 816,
                
            };
            manager = new WeekResultManager();

        }

        [TestMethod]
        public void DrawingBelongToWeekResult()
        {
            DrawingResult drawing = new DrawingResult()
            {
                Date = new DateTime(2019,1,8),
                Pick3 = 119,
                Pick4First = 96,
                Pick4Second = 62,
                Type = DrawType.Evening
               
            };
             
            var result = manager.IsDrawingBelongWeek(drawing, weekResult);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DrawingNotBelongToWeekResult()
        {
            DrawingResult drawing = new DrawingResult()
            {
                Date = new DateTime(2019, 1, 14),
                Pick3 = 762,
                Pick4First = 13,
                Pick4Second = 61,
                Type = DrawType.Evening

            };

            WeekResultManager manager = new WeekResultManager();
            DayOfWeek a = DateTime.Now.DayOfWeek;
            var s = Enum.GetNames(a.GetType());

            var result = manager.IsDrawingBelongWeek(drawing, weekResult);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetDayOfWeekOperation()
        {
            DateTime date = new DateTime(2019, 2, 1);

            int day = manager.GetDayOfWeek(date);

            Assert.AreEqual(5, day);
        }

        [TestMethod]
        public void InsertNullsAtTheBeginingInArray()
        {
            List<DrawingResult> drawingResultList = new List<DrawingResult>()
            {
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 14),
                    Pick3 = 762,
                    Pick4First = 13,
                    Pick4Second = 61,
                    Type = DrawType.Evening
                }
            };

            manager.CompletteNullsAtTheBegining(drawingResultList, 2);

            Assert.IsNull(drawingResultList[0]);
            Assert.AreEqual(3, drawingResultList.Count);
        }

        [TestMethod]
        public void InsertNullsAtTheEndInArray()
        {
            List<DrawingResult> drawingResultList = new List<DrawingResult>()
            {
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 14),
                    Pick3 = 762,
                    Pick4First = 13,
                    Pick4Second = 61,
                    Type = DrawType.Evening
                }
            };

            manager.CompletteNullsAtTheEnd(drawingResultList, 2);

            Assert.IsNotNull(drawingResultList[0]);
            Assert.IsNull(drawingResultList[2]);
            Assert.AreEqual(5, drawingResultList.Count);
        }

        [TestMethod]
        public void CreateWeekResultMethod()
        {
            List<DrawingResult> drawingResultList = new List<DrawingResult>()
            {
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 14),
                    Pick3 = 762,
                    Pick4First = 13,
                    Pick4Second = 61,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 15),
                    Pick3 = 525,
                    Pick4First = 55,
                    Pick4Second = 46,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 16),
                    Pick3 = 543,
                    Pick4First = 30,
                    Pick4Second = 55,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 17),
                    Pick3 = 647,
                    Pick4First = 59,
                    Pick4Second = 39,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 18),
                    Pick3 = 586,
                    Pick4First = 54,
                    Pick4Second = 13,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 19),
                    Pick3 = 954,
                    Pick4First = 2,
                    Pick4Second = 56,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 20),
                    Pick3 = 261,
                    Pick4First = 12,
                    Pick4Second = 5,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 21),
                    Pick3 = 916,
                    Pick4First = 47,
                    Pick4Second = 5,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019, 1, 22),
                    Pick3 = 277,
                    Pick4First = 68,
                    Pick4Second = 1,
                    Type = DrawType.Evening
                },
               
            };

            var lista = manager.CreateWeekResult(drawingResultList);

            Assert.AreEqual(2, lista.Count);
        }


    }
}
