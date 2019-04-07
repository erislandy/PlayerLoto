using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerLoto.Data;
using PlayerLoto.DataEF;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using PlayerLoto.Services;

namespace PlayerLoto.ServiceTest
{
    [TestClass]
    public class SimulationTest
    {
        DrawingResult drawing;
        List<int> last50NumbersDelayed_01012019MiddayExpected;
        ISessionFactory _sessionfactory;
        IRepository _repository;
        IAdvancedOperation operation;
        
        [TestInitialize]
        public void Setup()
        {
            drawing = new DrawingResult()
            {
                Date = new DateTime(2019, 2, 1),
                Pick3 = 534,
                Pick4First = 41,
                Pick4Second = 98,
                Type = DrawType.Evening
            };
            last50NumbersDelayed_01012019MiddayExpected = new List<int>()
            {
                10,46,50,97,80,39,72,26,60,42,45,75,78,48,88,70,93,73,64,
                76,1,29,12,71,21,82,41,67,5,99,13,90,30,44,2,36,17,83,22,58,
                91,38,15,33,40,94,51,68,27,3
            };

            _sessionfactory = new SessionFactory();
            _repository = new Repository(_sessionfactory);
            operation = new AdvancedOperation(_repository);
        }

        [TestMethod]
        public void GameManagerLast50DelayNumbersPlay()
        {
            IGameManager gameManager = new GameManagerLast50DelayNumbers(operation);
            gameManager.PlayGame(drawing.Date, drawing.Type);
            IList<int> numberList = gameManager.GetNumbers();
            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(last50NumbersDelayed_01012019MiddayExpected[i], numberList[i]);
            }
             
        }
    }
}
