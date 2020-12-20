using Autofac;
using FreePuzzle.Service.Modules;

using Xunit;
using Xunit.Abstractions;

namespace FreePuzzle.UnitTest
{
    public class TestBase
    {
        [Fact]
        public void GetFightAgainstLandlords()
        {
            Assert.Equal("138712181744994", 138712181744994.ToString());
        }

        public ITestOutputHelper Output;

        public TestBase()
        {
        }

        public TestBase(ITestOutputHelper testOutput)
        {
            Output = testOutput;
        }
        public static IContainer container
        {
            get
            {
                ContainerBuilder builder = new ContainerBuilder();
                ModuleEntry.Register(builder);
                return builder.Build();
            }
        }

        public static T IniType<T>()
        {
            return container.Resolve<T>();
        }
    }
}
