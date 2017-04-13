using Microsoft.AspNetCore.Mvc;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using StructureMap.Pipeline;
using StructureMap.TypeRules;
using System.Linq;


namespace SpecialApp.API.Infrastructure
{
    public class ControllerConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.AllTypes().Where(x => x.CanBeCastTo(typeof(Controller)) && !x.IsInterfaceOrAbstract()))
            {
                if (type.CanBeCastTo(typeof(Controller)) && !type.IsInterfaceOrAbstract())
                {
                    registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
                }
            }
        }
    }
}
