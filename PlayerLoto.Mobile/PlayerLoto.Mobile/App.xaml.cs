﻿using PlayerLoto.Mobile.Views;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PlayerLoto.Mobile
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(nameof(MasterView));
            /*

            if (!result.Success)
            {
              await  App.Current.MainPage.DisplayAlert("Error", result.Exception.Message, "Cancel");
        
            }
            */
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MasterView>();
         

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type queryDRModule = typeof(QueryDrawingResultsModule.ModuleDefinitions.Module);

            moduleCatalog.AddModule(
                    new ModuleInfo()
                    {
                        ModuleName = queryDRModule.Name,
                        ModuleType = queryDRModule,
                        InitializationMode = InitializationMode.WhenAvailable

                    }
                );

            Type dataBaseLocalServiceModule = typeof(DataBaseLocalService.ModuleDefinitions.Module);

            moduleCatalog.AddModule(
                    new ModuleInfo()
                    {
                        ModuleName = dataBaseLocalServiceModule.Name,
                        ModuleType = dataBaseLocalServiceModule,
                        InitializationMode = InitializationMode.WhenAvailable

                    }
                );

            Type generateNumbersModule = typeof(GenerateNumbersModule.ModuleDefinitions.Module);

            moduleCatalog.AddModule(
                    new ModuleInfo()
                    {
                        ModuleName = generateNumbersModule.Name,
                        ModuleType = generateNumbersModule,
                        InitializationMode = InitializationMode.WhenAvailable

                    }
                );

            Type cabalaModule = typeof(CabalaModule.ModuleDefinitions.Module);

            moduleCatalog.AddModule(
                    new ModuleInfo()
                    {
                        ModuleName = cabalaModule.Name,
                        ModuleType = cabalaModule,
                        InitializationMode = InitializationMode.WhenAvailable

                    }
                );

            base.ConfigureModuleCatalog(moduleCatalog);

        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
