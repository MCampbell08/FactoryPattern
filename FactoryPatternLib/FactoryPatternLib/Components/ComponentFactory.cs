using FactoryPatternLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public abstract class ComponentFactory
    {
        public abstract List<Components.Component> Components();
        
    }
}
