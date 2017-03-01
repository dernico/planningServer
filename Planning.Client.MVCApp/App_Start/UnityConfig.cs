using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Planning.Core;
using Planning.Core.Interfaces;
using Planning.Data;
using Unity.WebApi;

namespace Planning.Client.MVCApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ITodoRepository, TodoRepository>();
            container.RegisterType<ITodoBl, TodoBl>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}