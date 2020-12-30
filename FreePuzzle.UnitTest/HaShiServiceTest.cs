using FreePuzzle.Service;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
namespace FreePuzzle.UnitTest
{
    public class HaShiServiceTest :TestBase
    {
        public HaShiServiceTest(ITestOutputHelper testOutput) : base(testOutput)
        {

        }
        [Fact]
        public void Test()
        {
            var list = IniType<HaShiService>().Solve();
            Assert.Equal(36, list.Count);
            Assert.Equal(88, list.Sum(c=>c.Value));
        }
    }
}
