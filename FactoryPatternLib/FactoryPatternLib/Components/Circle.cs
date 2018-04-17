using FactoryPatternLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPatternLib.Components;

namespace FactoryPatternLib
{
    public class Circle : Component
    {
        private double topLoc;
        private double leftLoc;
        private double height;
        private double width;
        private string content;

        public override double TopLoc { get => topLoc; set => topLoc = value; }
        public override double LeftLoc { get => leftLoc; set => leftLoc = value; }
        public override string Content { get => content; set => content = value; }
        public override double Height { get => height; set => height = value; }
        public override double Width { get => width; set => width = value; }

        public override string ComponentString()
        {
            throw new NotImplementedException();
        }
    }
}
