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
    public class MenuViewModel : BindableBase
    {
        #region Services
        INavigationService _navigationService;
        #endregion

        #region Attributes

        List<Menu> _menuList;

        #endregion

        #region Properties
        public ObservableCollection<Menu> MyMenu
        {
            get;
            set;
        }
        #endregion

        #region Constructors

        public MenuViewModel(INavigationService navigationService)
        {
            _menuList = new List<Menu>()
            {
              new Menu(){ Title = "Historial", TargetPage="DiarioView"},
               new Menu(){ Title = "Generar", TargetPage="GenerateView"},
              new Menu(){ Title = "Estadística", TargetPage="StatisticView"},
              new Menu(){ Title = "Jugar", TargetPage="PlayView"}
            };
            MyMenu = new ObservableCollection<Menu>(_menuList);
            _navigationService = navigationService;

        }

        #endregion

        #region Commands

        public ICommand ItemTappedCommand
        {
            get
            {
                return new DelegateCommand<Menu>(ItemTappedMethod);
            }

        }

        private async void ItemTappedMethod(Menu menu)
        {
            await _navigationService.NavigateAsync(menu.TargetPage);
        }

        #endregion
    }
}
