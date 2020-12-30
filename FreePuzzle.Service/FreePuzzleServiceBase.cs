using AutoMapper;
using FreePuzzle.Models.Card;
using FreePuzzle.Service.Modules;
using System.Collections.Generic;

namespace FreePuzzle.Service
{
    public class FreePuzzleServiceBase : IFreePuzzleBase
    {
        /// <summary>
        /// 获取或设置 freeSql实例
        /// </summary>
        public IFreeSql freeSql { get; set; }

        /// <summary>
        /// 获取或设置 用于表与DTO对象进行映射
        /// </summary>
        public IMapper mapper { get; set; }


        public FreePuzzleServiceBase()
        {

        }
    }
}