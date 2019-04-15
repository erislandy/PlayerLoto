using System;
using System.Collections.Generic;
using System.Text;
using Prism.Ioc;
using Prism.Modularity;
using QueryDrawingResultsModule.Views;

namespace QueryDrawingResultsModule.ModuleDefinitions
{
    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DiarioView>();
            containerRegistry.RegisterForNavigation<FilterDayHistoryView>();
            containerRegistry.RegisterForNavigation<FilterWeekHistoryView>();

        }
    }
}
