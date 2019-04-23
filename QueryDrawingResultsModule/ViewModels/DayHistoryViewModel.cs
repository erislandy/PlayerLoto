using DataBaseLocalService.Filters;
using DataBaseLocalService.Services;
using PlayerLoto.Domain;
using PlayerLoto.Services.FilterOperation;
using Prism.Commands;
using Prism.Ioc;
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

        private readonly INavigationService _navigationService;
        private readonly IDataAccessService _dataAccessService;

        #endregion

        #region Constructors
        public DayHistoryViewModel(INavigationService navigationService, IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
            _navigationService = navigationService;
            var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var finalDate = DateTime.Now;
            var list = _dataAccessService.GetDrawingResultHistory(initialDate, finalDate);


            DrawingResultList = new ObservableCollection<DrawingResult>(list);

            FilterCommand = new DelegateCommand(FilterMethod);

        }

        #endregion


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
            if (parameters.Count == 0)
            {
                return;
            }

            


            var initialDate = (DateTime)parameters["initialDate"];
            var finalDate = (DateTime)parameters["finalDate"];
            var drawingState = (DrawingState)parameters["drawingState"];
            var parameterType = (ParameterType)parameters["parameterType"];
            var number = (int?)parameters["number"];

            var filterByDate = new DrawingResultLocalFilterByDate(_dataAccessService,initialDate,finalDate);
            var filterByType = new DrawingResultFilterByType(filterByDate, drawingState);

            var filterByParameter = new DrawingResultFilterByParameter(filterByType, number, parameterType);

            var list = filterByParameter.Filter();

            DrawingResultList = new ObservableCollection<DrawingResult>(list);

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }


        #endregion

    }
}
