using StructureMap;

namespace SpecialApp.UnitOfWork
{
    public class UOWRegistry : Registry
    {
        public UOWRegistry()
        {
            Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });
        }
    }
}