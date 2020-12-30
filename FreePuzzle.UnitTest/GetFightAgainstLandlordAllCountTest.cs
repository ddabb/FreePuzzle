using FreePuzzle.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
namespace FreePuzzle.UnitTest
{
    public class GetFightAgainstLandlordAllCountTest:TestBase
    {
        public GetFightAgainstLandlordAllCountTest(ITestOutputHelper testOutput):base(testOutput)
        {

        }
        [Fact]
        public void Test()
        {
           Output.WriteLine( IniType<GetFightAgainstLandlordAllCountService>().Solve().Desciption);
        }
    }
}
