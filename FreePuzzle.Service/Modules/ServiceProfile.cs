using Autofac;
using AutoMapper;
using FreePuzzle.Models.Card;

using System.Linq;
using System.Reflection;

namespace FreePuzzle.Service.Modules
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {

            Assembly modelsAssembly = typeof(CardBase).Assembly;
            var types = modelsAssembly.GetTypes()
                .Where(type => type.GetCustomAttributes(typeof(MapperAttribute), true).Any()).ToArray();

            if (types.Any())
            {
                foreach (var type in types)
                {
                    var attributes = type.GetCustomAttributes(typeof(MapperAttribute), false);
                    if (attributes.Any())
                    {
                        var mapper =
                            (MapperAttribute)attributes.First(c => c is MapperAttribute);
                        foreach (var type1 in mapper.Types)
                        {
                            CreateMap(type, type1);
                            CreateMap(type1, type);
                        }
                    }
                }
            }

        }
    }
}
