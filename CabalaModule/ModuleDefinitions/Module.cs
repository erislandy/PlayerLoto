using CabalaModule.Implementations;
using CabalaModule.Views;
using PlayerLoto.Domain.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabalaModule.ModuleDefinitions
{
    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICabalaManager, CabalaLocalManager>();
            containerRegistry.RegisterForNavigation<CabalaView>();
        }
    }
}
