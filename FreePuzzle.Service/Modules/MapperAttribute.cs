using System;

namespace FreePuzzle.Service.Modules
{
    /// <summary>
    /// 该特性用于做automapper映射，和限定model引用dto的关系
    /// </summary>
    public class MapperAttribute : Attribute
    {
        public Type[] Types;
        public MapperAttribute(params Type[] types)
        {
            Types = types;
        }
    }
}
