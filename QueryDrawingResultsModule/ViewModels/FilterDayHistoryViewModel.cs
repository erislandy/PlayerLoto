using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using QueryDrawingResultsModule.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace QueryDrawingResultsModule.ViewModels
{
    public class FilterDayHistoryViewModel : BindableBase
    {
        #region Attributes

        DrawingResultFilter _filter;

        #endregion

        #region Services

        INavigationService _navigationService;

        #endregion

        #region Properties

        public DrawingResultFilter Filter
        {
            get => _filter;
            set => SetProperty(ref _filter, value);
        }

        #endregion

        #region Constructors
        public FilterDayHistoryViewModel(INavigationService navigationService)
        {
            Filter = new DrawingResultFilter()
            {
                Parameter = 125
            };

            SubmitCommand = new DelegateCommand(SubmitMethod);

            _navigationService = navigationService;
        }

       

        #endregion

        #region Commands

        public ICommand SubmitCommand
        {
            get; set;
        }

        #endregion

        #region Methods

        private async void SubmitMethod()
        {
            var parameters = new NavigationParameters();
            parameters.Add("initialDate",Filter.InitialDate);
            parameters.Add("finalDate", Filter.FinalDate);
            parameters.Add("drawingState", Filter.DrawingState);
            parameters.Add("parameterType", Filter.ParameterType);
            parameters.Add("number", Filter.Parameter);

            await _navigationService.GoBackAsync(parameters);
            
        }

        #endregion

    }
}
