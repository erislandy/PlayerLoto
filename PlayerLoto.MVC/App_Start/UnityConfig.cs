using PlayerLoto.Data;
using PlayerLoto.DataEF;
using PlayerLoto.Domain.Interfaces;
using PlayerLoto.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PlayerLoto.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ISessionFactory, SessionFactory>();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IAdvancedOperation, AdvancedOperation>();
            container.RegisterType<IGameManager, GameManagerLast50DelayNumbers>("Ultimos50NumerosDemorados");
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}