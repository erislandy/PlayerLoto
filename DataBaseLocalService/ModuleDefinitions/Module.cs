using DataBaseLocalService.Services;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.ModuleDefinitions
{
    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(typeof(DataAccessService), new DataAccessService());
        }
    }
}
