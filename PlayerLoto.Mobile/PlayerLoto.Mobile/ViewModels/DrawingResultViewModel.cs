using PlayerLoto.Mobile.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlayerLoto.Mobile.ViewModels
{
    public class DrawingResultViewModel : BindableBase
    {
        #region Attributes
        List<DrawingResult> _drawingResultList;
        

        #endregion

        #region Properties

        public ObservableCollection<DrawingResult> DrawingResultList
        {
            get;
        }

        #endregion
        #region Constructors
        public DrawingResultViewModel()
        {
            _drawingResultList = new List<DrawingResult>()
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


            DrawingResultList = new ObservableCollection<DrawingResult>(_drawingResultList);
        }
        #endregion
    }
}
