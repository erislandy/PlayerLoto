using DataBaseLocalService.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace GenerateNumbersModule.ViewModels
{
    public class GenerateNumbersViewModel : BindableBase
    {
        #region Atributes

        string _text;

        #endregion

        #region Properties

        public int Amount { get; set; }
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        #endregion

        #region Services

        IDataAccessService _dataAccessService;

        #endregion

        #region Constructors
        public GenerateNumbersViewModel(IDataAccessService dataAccessService)
        {
            Text = "";
            GenerateNumbersCommand = new DelegateCommand<string>(GenerateNumbersMethod);
            _dataAccessService = dataAccessService;
        }

       
        #endregion

        #region Commands

        public ICommand GenerateNumbersCommand
        {
            get; set;
        }
        #endregion

        #region Methods

        private void GenerateNumbersMethod(string text)
        {
            Amount = int.Parse(text);
            Thread a = new Thread(GetNumbersMethod);
            a.Start();
            
            
        }

        private void GetNumbersMethod(object obj)
        {
            for (int i = 0; i < 20; i++)
            {
                Random rdn = new Random();
                Thread.Sleep(30);
                int n = rdn.Next(99);
                string str = string.Empty;
                for (int j = 0; j < Amount; j++)
                {
                    str = str + " " + n;
                }
                Text = GetListNumberByAmount(Amount);
                
            }
            
        }

        private string GetListNumberByAmount(int amount)
        {
            string str = string.Empty;
            var list = _dataAccessService.GetNumberList().ToList();

            
            for (int i = 0; i < amount; i++)
            {
                var randon = new Random();
                int position = randon.Next(0, list.Count);
                str = str + " " + list[position].ToString();
                list.RemoveAt(position);
            }

            return str;

        }

        #endregion

    }
}
