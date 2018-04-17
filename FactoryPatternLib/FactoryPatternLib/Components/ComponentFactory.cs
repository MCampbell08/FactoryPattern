using FactoryPatternLib.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public abstract class ComponentFactory
    {
        public abstract Components.Component CreateComponent(Enums.Components component, double height, double width, double leftLoc, double topLoc, string content);
        public abstract void Compile(ObservableCollection<Components.Component> observableCollection);
        public abstract void Display();
    }
}
