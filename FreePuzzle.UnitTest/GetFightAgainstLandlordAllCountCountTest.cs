using FreePuzzle.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FreePuzzle.UnitTest
{
    public class GetFightAgainstLandlordAllCountCountTest:TestBase
    {
        [Fact(Skip ="数据库配置不正确")]
        public void Test()
        {
            IniType<GetFightAgainstLandlordAllCountCountService>().Solve();
        }
    }
}
