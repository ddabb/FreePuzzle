using AutoMapper;

namespace FreePuzzle.Service
{
    public class ServiceBase
    {
        public IFreeSql orm { get; set; }

        public Mapper mapper { get; set; }
    }
}
