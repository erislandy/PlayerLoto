using DataBaseLocalService.Filters;
using DataBaseLocalService.Services;
using PlayerLoto.Domain;
using PlayerLoto.Services;
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
    public class WeekHistoryViewModel : BindableBase, INavigationAware
    {
        #region Attributes

        ObservableCollection<WeekResult> _weekResultList;
        DrawType _drawType;

        #endregion

        #region Properties

        public DrawType DrawType
        {
            get => _drawType;
            set => SetProperty(ref _drawType, value);
        }
        public ObservableCollection<WeekResult> WeekResultList
        {
            get => _weekResultList;
            set => SetProperty(ref _weekResultList, value);
        }
        #endregion

        #region Services

        private readonly INavigationService _navigationService;
        private readonly DataAccessService _dataAccessService;

        #endregion


        #region Constructors

        public WeekHistoryViewModel(INavigationService navigationService, DataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
            _navigationService = navigationService;
            FilterCommand = new DelegateCommand(FilterMethod);

            var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var finalDate = DateTime.Now;
            var state = DrawingState.Midday;
            var filterByDate = new DrawingResultLocalFilterByDate(_dataAccessService, initialDate, finalDate);
            var filter = new DrawingResultFilterByType(filterByDate, state);
            var manager = new WeekResultManager();
            var list = filter.Filter();
            DrawType = list[0].Type;
            WeekResultList = new ObservableCollection<WeekResult>(manager.CreateWeekResult(list));
        }
        #endregion

        #region Commands

        public ICommand FilterCommand { get; set; }

        #endregion

        #region Methods

        private async void FilterMethod()
        {
            await _navigationService.NavigateAsync("FilterWeekHistoryView");
        }



        #endregion

        #region INavigationAware Implementation

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Count == 0)
            {
                return;
            }




            var initialDate = (DateTime)parameters["initialDate"];
            var finalDate = (DateTime)parameters["finalDate"];
            var drawingState = (DrawingState)parameters["drawingState"];
           
            var filterByDate = new DrawingResultLocalFilterByDate(
                                                                        _dataAccessService,
                                                                        initialDate,
                                                                        finalDate);
            var filterByType = new DrawingResultFilterByType(filterByDate, drawingState);

            var list = filterByType.Filter();

            var manager = new WeekResultManager();
            DrawType = list[0].Type;
            WeekResultList = new ObservableCollection<WeekResult>(manager.CreateWeekResult(list));

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }


        #endregion

    }
}
