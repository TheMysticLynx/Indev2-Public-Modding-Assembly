using System;
using System.Collections.Generic;

namespace PublicAssembly
{
    public interface IMod
    {
        public string Name { get; }
        public Version Version { get; }
        public string Description { get; }
        public IEnumerable<Type> CellUpdateOrder { get; }
    }
}