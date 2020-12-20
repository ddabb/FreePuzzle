using Autofac;
using AutoMapper;

using System.Text;

namespace FreePuzzle.Service.Modules
{
    public class AutoMapperModule : Module
    {
        public AutoMapperModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            MapperConfiguration _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });

            var mapper = _mapperConfiguration.CreateMapper();

            builder.Register(t => mapper).As<IMapper>();
        }
    }
}
