using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib.Components
{
    public class WPFComponentFactory : ComponentFactory
    {
        public override List<Component> Components()
        {
            return new List<Component>() { new Button(), new Textbox() };
        }
    }
}
