using FreePuzzle.Service;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
namespace FreePuzzle.UnitTest
{
    public class HaShiServiceTest : TestBase
    {
        public HaShiServiceTest(ITestOutputHelper testOutput) : base(testOutput)
        {

        }
        [Fact]
        public void Test()
        {
            var list = IniType<HaShiService>().Solve();
            Assert.Equal(36, list.Count);
            Assert.Equal(88, list.Sum(c => c.Value));
            foreach (var item in list)
            {
                Output.WriteLine($"Index {item.Index} Row {item.Row} Column {item.Column} TopIndex {item.TopIndex}  LeftIndex {item.LeftIndex}  RightIndex {item.RightIndex}  BottomIndex {item.BottomIndex}");
            }

            //var temp = list.SelectMany(c => c.IndexMaps).ToList();
            //Output.WriteLine($"组合可能数{temp.Count}");
            //foreach (var item in temp)
            //{
            //    Output.WriteLine($"item.StartIndex {item.StartIndex}  item.EndIndex{item.EndIndex}");
            //}
     
        }
    }
}
