using Autofac;
using System.Linq;

namespace FreePuzzle.Service.Modules
{
    public class ServiceModule : Module
    {
        public ServiceModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceBase>();
            var types = typeof(ServiceBase).Assembly.GetTypes().Where(t => !t.IsAbstract && t.GetInterfaces().Contains(typeof(IFreePuzzleBase)));
            foreach (var type in types)
            {
                builder.RegisterType(type).AsSelf().PropertiesAutowired();
            }
        }
    }
}
