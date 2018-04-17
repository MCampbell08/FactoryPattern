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
            return $"<canvas id=\"myCanvas\"  width=\"1000\" height=\"1000\" style=\"border: 1px solid #d3d3d3;\"></canvas>\n" +
                            $"<script>\n" +
                            $"var c = document.getElementById('myCanvas');\n" +
                            $"var ctx = c.getContext(\"{Content}\")\n" +
                            $"ctx.beginPath();\n" +
                            $"ctx.arc({LeftLoc}, {TopLoc}, {Width / 2}, 0, 2 * 3.14);\n" +
                            $"ctx.stroke();\n" +
                            $"</script>";
        }
    }
}
