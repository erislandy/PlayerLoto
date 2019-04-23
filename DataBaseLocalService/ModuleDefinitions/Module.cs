

namespace DataBaseLocalService.ModuleDefinitions
{
    using DataBaseLocalService.Helpers;
    using DataBaseLocalService.Services;
    using Prism.Ioc;
    using Prism.Modularity;
    using Unity;

    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
            containerRegistry.Register<IDataAccess, DataAccess>();
            containerRegistry.Register<IDataAccessService, DataAccessService>();
        }
    }
}
