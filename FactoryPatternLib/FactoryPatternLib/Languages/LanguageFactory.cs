using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FactoryPatternLib
{
    public abstract class LanguageFactory
    {
        public abstract ObservableCollection<UI_Component> Components { get; set; }
        public abstract void Compile();
        public abstract void Display();
        public abstract void CreateComponent();
    }
}
