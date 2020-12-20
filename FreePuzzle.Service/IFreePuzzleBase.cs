using AutoMapper;
using FreePuzzle.Models.Card;
using System.Collections.Generic;

namespace FreePuzzle.Service.Modules
{
    public interface IFreePuzzleBase
    {        /// <summary>
             /// 获取或设置 freeSql实例
             /// </summary>
        IFreeSql freeSql { get; set; }

        /// <summary>
        /// 获取或设置 用于表与DTO对象进行映射
        /// </summary>
        IMapper mapper { get; set; }

    }
}