using FactoryPatternLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public abstract class UI_Component
    {
        public abstract Component Component { get; set; }
        public abstract double TopLoc { get; set; }
        public abstract double LeftLoc { get; set; }
        public abstract string Content { get; set; }
        public abstract double Height { get; set; }
        public abstract double Width { get; set; }
    }
}
