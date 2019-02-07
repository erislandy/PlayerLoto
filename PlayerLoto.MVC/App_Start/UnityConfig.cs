using PlayerLoto.Data;
using PlayerLoto.DataEF;
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


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}