using PlayerLoto.Mobile.ModelsUI;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PlayerLoto.Mobile.ViewModels
{
    public class DetailViewModel : BindableBase
    {
        #region Services

        INavigationService _navigationService;

        #endregion

        #region Attributes

        List<Option> _optionsList;

        #endregion

        #region Properties
        public ObservableCollection<Option> OptionsList { get; set; }

        #endregion

        #region Constructors

        public DetailViewModel(INavigationService navigationService)
        {
            _optionsList = new List<Option>()
            {
                new Option()
                {
                    Name = "Diario",
                    Description ="Consulta los tiros diarios dia/noche en un intervalo de fechas.",
                    TargetPage="DiarioView"
                },
                new Option()
                {
                    Name = "Semanal",
                    Description ="Puedes ver el cartón de la lotería dia/noche.",
                    TargetPage = "Page1"
                },
                new Option()
                {
                    Name = "Mensual",
                    Description ="Compara los resultados de un mes específico en diferentes años.",
                    TargetPage="MensualView"
                },
                new Option()
                {
                    Name = "Anual",
                    Description ="Compara los resultados de un año específico en diferentes meses.",
                    TargetPage="ManagerView"
                },
                new Option()
                {
                    Name = "Generar",
                    Description ="Puedes generar en 3 ocasiones números probables a salir en el dia.",
                    TargetPage="GenerateView"
                },
                new Option()
                {
                    Name = "Estadística",
                    Description ="Números probables en el mes, Números mas demorados en salir",
                    TargetPage="ProbabilidadView"
                },
                new Option()
                {
                    Name = "Jugar",
                    Description ="Guarda tus jugadas, distribuye tu jugada teniendo en cuenta los limitados de distintos bancos",
                    TargetPage="JugarView"
                }

            };

            OptionsList = new ObservableCollection<Option>(_optionsList);



            _navigationService = navigationService;
        }


        #endregion

        #region Commands

        public ICommand NavigationCommand

        {
            get
            {
                return new DelegateCommand<Option>(NavigationMethod);
            }
        }

        private async void NavigationMethod(Option option)
        {
           await _navigationService.NavigateAsync(option.TargetPage);
        }

        #endregion
    }
}
