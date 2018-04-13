using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public class Image : UI_Component
    {
        public override double TopLoc { get => TopLoc; set => TopLoc = value; }
        public override double LeftLoc { get => LeftLoc; set => LeftLoc = value; }
        public override string Content { get => Content; set => Content = value; }
        public override double Height { get => Height; set => Height = value; }
        public override double Width { get => Width; set => Width = value; }
    }
}
