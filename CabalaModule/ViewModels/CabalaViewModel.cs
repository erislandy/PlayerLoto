using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabalaModule.ViewModels
{
    public class CabalaViewModel : BindableBase
    {
        string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        public CabalaViewModel()
        {
            Text = "Cabala module ok";
        }
    }
}
