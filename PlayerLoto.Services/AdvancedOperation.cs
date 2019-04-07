using PlayerLoto.Data;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using PlayerLoto.Services.FilterOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Services
{
    public class AdvancedOperation : IAdvancedOperation
    {
        IRepository _repository;
        public AdvancedOperation(IRepository repository)
        {
            _repository = repository;
        }
        public List<Delay> GetDelays(DateTime initialDate, DateTime finalDate, DrawType type)
        {
            var delayList = new List<Delay>();

            var filterbyDate = new DrawingResultFilterByDate(_repository, initialDate, finalDate);

            DrawingState state = (DrawingState)Enum.Parse(typeof(DrawingState), type.ToString());
            var filterByeType = new DrawingResultFilterByType(filterbyDate, state);

            var drawingList = filterByeType.Filter();

            DateTime iniLast3year = initialDate.AddYears(-3);
            var drawingList3YearEarlier = _repository.GetList<DrawingResult>(
                                                     d => d.Type == type &&
                                                     d.Date >= iniLast3year &&
                                                     d.Date < initialDate)
                                                     .ToList();

            var drawingListComplette = drawingList3YearEarlier
                                                .Concat(drawingList)
                                                .OrderByDescending(d => d.Date)
                                                .ToList();

            foreach (var drawing in drawingList)
            {
                delayList.Add(
                    new Delay()
                    {
                        Days = AmountDaysOfLastDrawing(drawing, drawingListComplette),
                        DrawingResult = drawing
                    }
                    );
            }

            return delayList;
        }

        public Delay GetAmountDayForPick3Tens(int pick3, DateTime dateTime, DrawType type)
        {
            var date = dateTime.AddYears(-3);
            var drawingList = _repository.GetList<DrawingResult>(
                                                d => d.Date > date &&
                                                d.Date <= dateTime &&
                                                d.Type == type)
                                                .OrderByDescending(d => d.Date)
                                                .ToList();
            var drawingTest = new DrawingResult()
            {
                Type = type,
                Date = dateTime,
                Pick3 = pick3
            };
            return new Delay()
            {
                DrawingResult = drawingTest,
                Days = AmountDaysOfLastDrawing(drawingTest, drawingList)
            };
        }
        private int AmountDaysOfLastDrawing(DrawingResult drawing, List<DrawingResult> drawingListComplette)
        {
            var list = drawingListComplette.Where(d => d.Date < drawing.Date)
                                           .ToList();
            int parameter;
            var drawingLast = new DrawingResult();
            Math.DivRem(drawing.Pick3, 100, out parameter);

            foreach (var item in list)
            {
                
                if(Pick3TenExist(item, parameter))
                {
                    drawingLast = item;
                    break;
                }
            }
            return (int)drawing.Date.Subtract(drawingLast.Date).TotalDays;
        }

        private bool Pick3TenExist(DrawingResult drawing, int? parameter)
        {
            int result;
            var decenaFijo = Math.DivRem(drawing.Pick3, 100, out result);
            return (result == parameter);

        }
        
        public List<int> GetPath(List<int> listNumber, DateTime initialDate, DateTime finalDate, DrawType type)
        {
            
            var filterbyDate = new DrawingResultFilterByDate(_repository, initialDate, finalDate);

            DrawingState state = (DrawingState)Enum.Parse(typeof(DrawingState), type.ToString());
            var filterByeType = new DrawingResultFilterByType(filterbyDate, state);

            var drawingList = filterByeType.Filter().OrderBy(d => d.Date).ToList();

            List<int> list = new List<int>();

            int days = 0;
            DateTime iniDate = initialDate;
            foreach (var drawing in drawingList)
            {
                if(IsMemberDrawing(drawing, listNumber))
                {
                    days = (int)drawing.Date.Subtract(iniDate).TotalDays;
                    list.Add(days);
                    days = 0;
                    iniDate = drawing.Date;
                }
                
            }
            days = -1* (int)drawingList.Last().Date.Subtract(iniDate).TotalDays;
            list.Add(days);

            return list;
        }
        
        public bool IsMemberDrawing(DrawingResult drawing, List<int> listNumber)
        {
            int parameter = 0;
            Math.DivRem(drawing.Pick3, 100, out parameter);
            return listNumber.Contains(parameter);
            
        }
    }
}