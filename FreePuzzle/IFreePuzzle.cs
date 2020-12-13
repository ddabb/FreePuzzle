using System;
using System.Collections.Generic;
using System.Text;

namespace FreePuzzle
{
    /// <summary>
    /// 所有谜题都实现该接口
    /// </summary>
    public interface IFreePuzzle
    {

        Solution Solve();
    }
}
