using StructureMap;

namespace SpecialApp.Base.Infrastructure
{
    public class BaseRegistry : Registry
    {
        public BaseRegistry()
        {
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}