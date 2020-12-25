using FreePuzzle.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace FreePuzzle.UnitTest
{
    public class GetFightAgainstLandlordAllCountCountTest:TestBase
    {
        public GetFightAgainstLandlordAllCountCountTest(ITestOutputHelper testOutput):base(testOutput)
        {

        }
        [Fact]
        public void Test()
        {
           Output.WriteLine( IniType<GetFightAgainstLandlordAllCountCountService>().Solve().Desciption);
        }
    }
}
