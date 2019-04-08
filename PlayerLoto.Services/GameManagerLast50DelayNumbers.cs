using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Services
{
    public class GameManagerLast50DelayNumbers : IGameManager
    {
        private IList<int> numberList;
        IAdvancedOperation _operation;
        public GameManagerLast50DelayNumbers(IAdvancedOperation operation)
        {
            numberList = new List<int>();
            _operation = operation;
        }

        public IList<int> GetNumbers()
        {
            return numberList;
        }

        public void ClearList()
        {
            numberList.Clear();
        }

        public void PlayGame(DateTime date, DrawType drawType)
        {
            var delayList = new List<Delay>();

            for (int i = 0; i < 100; i++)
            {
                var delay = _operation.GetAmountDayForPick3Tens(i, date, drawType);
                delayList.Add(delay);
            }

            var delayOrderedList = delayList.OrderByDescending(d => d.Days)
                                   .Take(50)
                                   .ToList();

            foreach (var delay in delayOrderedList)
            {
                int parameter = 0;
                Math.DivRem(delay.DrawingResult.Pick3, 100, out parameter);
                numberList.Add(parameter);
            }
        }
    }
}
