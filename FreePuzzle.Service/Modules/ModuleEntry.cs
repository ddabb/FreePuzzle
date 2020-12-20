using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
namespace FreePuzzle.Service.Modules
{
    public class ModuleEntry
    {
        public static void Register(ContainerBuilder builder)
        {

            //builder.RegisterModule(new FreeSqlModule());
            //builder.RegisterModule(new AutoMapperModule());
            //builder.RegisterModule(new ServiceModule());

            builder.RegisterAssemblyModules(typeof(ModuleEntry).Assembly);
        }
    }
}
