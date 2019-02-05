using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using PlayerLoto.Data;
using PlayerLoto.Domain;
using PlayerLoto.Services;

namespace PlayerLoto.ServiceTest
{
    [TestClass]
    public class DrawingResultManagerFixure
    {
        List<DrawingResult> list;
        Mock<IRepository> repoMock;

        [TestInitialize]
        public void Setup()
        {
            list = new List<DrawingResult>()
            {
                new DrawingResult()
                {
                    Date = new DateTime(2013, 12, 1),
                    Pick3 = 833,
                    Type = DrawType.Evening,
                    Pick4First = 67,
                    Pick4Second = 3
                },
                new DrawingResult()
                {
                    Date = new DateTime(2013, 12, 1),
                    Pick3 = 6,
                    Type = DrawType.Midday,
                    Pick4First = 15,
                    Pick4Second = 0
                },
                new DrawingResult()
                {
                    Date = new DateTime(2013, 12, 2),
                    Pick3 = 766,
                    Type = DrawType.Evening,
                    Pick4First = 43,
                    Pick4Second = 97
                },
                new DrawingResult()
                {

                    Date = new DateTime(2013, 12, 2),
                    Pick3 = 364,
                    Type = DrawType.Midday,
                    Pick4First = 76,
                    Pick4Second = 51
                },
            };

            repoMock = new Mock<IRepository>();
            repoMock.Setup(m => m.GetList<DrawingResult>())
                    .Returns(list);

        }

        [TestMethod]
        public void GetDrawingByDate()
        {
            //Setup
            DrawingResultManager manager = new DrawingResultManager(repoMock.Object);
            DateTime date = new DateTime(2013, 12, 2);

            //Act
            var drawExpectedMid = manager.GetDrawingByDate(date, DrawType.Midday);
            var drawExpectedEve = manager.GetDrawingByDate(date, DrawType.Evening);

            //Asserts

            Assert.AreEqual(364, drawExpectedMid.Pick3);
            Assert.AreEqual(766, drawExpectedEve.Pick3);

        }
    }
}
