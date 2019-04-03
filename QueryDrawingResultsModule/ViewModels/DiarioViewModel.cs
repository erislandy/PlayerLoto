using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryDrawingResultsModule.ViewModels
{
    public class DiarioViewModel : BindableBase
    {
        string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        public DiarioViewModel()
        {
            Text = "QueryDrawingResult module ok";
        }
    }
}
