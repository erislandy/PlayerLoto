using PlayerLoto.Domain;
using PlayerLoto.Services.FilterOperation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace QueryDrawingResultsModule.ViewModels
{
    public class DayHistoryViewModel : BindableBase, INavigationAware
    {
        #region Attributes

        ObservableCollection<DrawingResult> _drawingResult;

        #endregion

        #region Properties

        public ObservableCollection<DrawingResult> DrawingResultList
        {
            get
            {
                return _drawingResult;
            }
            set
            {
                SetProperty(ref _drawingResult, value);
            }
        }

        #endregion

        #region Services

        INavigationService _navigationService;

        #endregion
        public DayHistoryViewModel(INavigationService navigationService)
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

            FilterCommand = new DelegateCommand(FilterMethod);

            _navigationService = navigationService;
        }

       
        #region Commands

        public ICommand FilterCommand { get; set; }

        #endregion

        #region Methods

        private async void FilterMethod()
        {
            await _navigationService.NavigateAsync("FilterDayHistoryView");
        }



        #endregion

        #region INavigationAware Implementation

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if(parameters.Count == 0)
            {
                return;
            }
            var list = new List<DrawingResult>();
            var enumerator = DrawingResultList.GetEnumerator();
            
            while(enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            if (parameters.ContainsKey("initialDate")&& 
                parameters.ContainsKey("finalDate"))
            {
                var initialDate = (DateTime)parameters["initialDate"];
                var finaldate = (DateTime)parameters["finalDate"];

                list.RemoveAll(d => d.Date < initialDate || d.Date > finaldate);
                
               
            }
            if (parameters.ContainsKey("drawingState"))
            {
                var drawingType = (DrawingState)parameters["drawingState"];
                if(drawingType != DrawingState.All)
                {
                    DrawType drawType = (DrawType)Enum.Parse(
                                                            typeof(DrawType),
                                                            drawingType.ToString());

                    list.RemoveAll(d => d.Type != drawType);
                   
                }
            }

            if (parameters.ContainsKey("parameterType"))
            {
                var parameterType = (ParameterType)parameters["parameterType"];
                
            }

            if (parameters.ContainsKey("number"))
            {
                var number = (int)parameters["number"];
                //Filtrar y actualizar DrawingResultList
            }

            DrawingResultList = new ObservableCollection<DrawingResult>(list);

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        #endregion


    }
}
