using Autofac;
using FreePuzzle.Models.Card;

namespace FreePuzzle.Service.Modules
{
    public class EntityModule : Module
    {
        public EntityModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            var baseType = typeof(ICardBase);
            System.Reflection.Assembly assembly = baseType.Assembly;  

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => baseType.IsAssignableFrom(t) && t.IsClass)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
