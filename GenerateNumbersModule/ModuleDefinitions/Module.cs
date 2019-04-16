
namespace GenerateNumbersModule.ModuleDefinitions
{
    using DataBaseLocalService.Services;
    using GenerateNumbersModule.Views;
    using Prism.Ioc;
    using Prism.Modularity;
    public class Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(typeof(DataAccessService), new DataAccessService());
            containerRegistry.RegisterForNavigation<GenerateNumbersView>();
        }
    }
}
