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
    public class FilterWeekHistoryViewModel : BindableBase
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
        public List<string> DrawingStateList
        {
            get
            {
                return new List<string>()
                {
                    "Midday",
                    "Evening"
                };
            }
        }

        #endregion

        #region Constructors
        public FilterWeekHistoryViewModel(INavigationService navigationService)
        {
            Filter = new DrawingResultFilter();
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
            parameters.Add("initialDate", Filter.InitialDate);
            parameters.Add("finalDate", Filter.FinalDate);
            parameters.Add("drawingState", Filter.DrawingState);
          
            await _navigationService.GoBackAsync(parameters);

        }

        #endregion
    }
}
