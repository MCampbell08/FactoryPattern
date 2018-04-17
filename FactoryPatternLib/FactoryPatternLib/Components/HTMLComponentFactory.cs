using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPatternLib.Enums;

namespace FactoryPatternLib.Components
{
    public class HTMLComponentFactory : ComponentFactory
    {
        public override List<Component> Components()
        {
            return new List<Component>() {  new Button(), new Circle(), new Image(), new Textbox() };
        }
    }
}
