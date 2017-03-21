using StructureMap;
using System;
using System.Threading;

namespace SpecialApp.Base
{
    public static class SpecialObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
                new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            return new Container(x =>
            {
                // default config
            });
        }
    }
}