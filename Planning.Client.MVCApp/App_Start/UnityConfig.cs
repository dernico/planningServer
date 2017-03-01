using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Planning.Core;
using Planning.Core.Interfaces;
using Planning.Data;
using Unity.Mvc5;

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
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}