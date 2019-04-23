using CabalaModule.Models;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CabalaModule.ViewModels
{
    public class CabalaViewModel : BindableBase
    {
        #region Attributes

        string _word;
        bool _numberVisibility;
        int _number;
        string _description;
        bool _listVisibility;
        ObservableCollection<Cabala_Word> _cabala_Words;
        #endregion

        #region Properties
        public string Word
        {
            get => _word;
            set => SetProperty(ref _word, value);
        }
        public bool NumberVisibility
        {
            get => _numberVisibility;
            set => SetProperty(ref _numberVisibility, value);
        }

        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        public bool ListVisibility
        {
            get => _listVisibility;
            set => SetProperty(ref _listVisibility, value);
        }

        public ObservableCollection<Cabala_Word> Cabala_Words
        {
            get => _cabala_Words;
            set => SetProperty(ref _cabala_Words, value);
        }

        #endregion

        #region Services

        ICabalaManager _manager;

        #endregion

        #region Constructors
        public CabalaViewModel(ICabalaManager manager)
        {
            _manager = manager;
            SearchCommand = new DelegateCommand(SearchMethod);
        }

        #endregion

        #region Commands
        public ICommand SearchCommand { get; set; }

        #endregion
       
        #region Methods
        private void SearchMethod()
        {
            int number;
            var cabala_Words = new List<Cabala_Word>();
            Cabala_Number cabalaNumber;
            bool success = int.TryParse(Word, out number);
            NumberVisibility = false;
            ListVisibility = false;

            if (success)
            {
                cabalaNumber = _manager.FindByNumber(number);
                NumberVisibility = true;
                Number = cabalaNumber.Number;
                Description = cabalaNumber.Description;
            }

            else
            {
                cabala_Words = _manager.FindbyWord(Word);
                Cabala_Words = new ObservableCollection<Cabala_Word>(cabala_Words);
                ListVisibility = true;

            }

        }


        #endregion

    }
}
