using PlayerLoto.Domain;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QueryDrawingResultsModule.ViewModels
{
    public class DayHistoryViewModel : BindableBase
    {
        

        #region Properties

        public ObservableCollection<DrawingResult> DrawingResultList { get; set; }
        #endregion
        public DayHistoryViewModel()
        {
            var list = new List<DrawingResult>()
            {
                new DrawingResult()
                {
                    Date = new DateTime(2019,1,1),
                    Pick3 = 675,
                    Pick4First = 88,
                    Pick4Second = 75,
                    Type = DrawType.Midday
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019,1,1),
                    Pick3 = 694,
                    Pick4First = 34,
                    Pick4Second = 48,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019,1,2),
                    Pick3 = 588,
                    Pick4First = 20,
                    Pick4Second = 82,
                    Type = DrawType.Midday
                },
                new DrawingResult()
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
                new DrawingResult()
                {
                    Date = new DateTime(2019,1,3),
                    Pick3 = 941,
                    Pick4First = 75,
                    Pick4Second = 16,
                    Type = DrawType.Evening
                },
                 new DrawingResult()
                {
                    Date = new DateTime(2019,1,1),
                    Pick3 = 694,
                    Pick4First = 34,
                    Pick4Second = 48,
                    Type = DrawType.Evening
                },
                new DrawingResult()
                {
                    Date = new DateTime(2019,1,2),
                    Pick3 = 588,
                    Pick4First = 20,
                    Pick4Second = 82,
                    Type = DrawType.Midday
                },
                new DrawingResult()
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
                new DrawingResult()
                {
                    Date = new DateTime(2019,1,3),
                    Pick3 = 941,
                    Pick4First = 75,
                    Pick4Second = 16,
                    Type = DrawType.Evening
                }
            };

            DrawingResultList = new ObservableCollection<DrawingResult>(list);
        }
    }
}
