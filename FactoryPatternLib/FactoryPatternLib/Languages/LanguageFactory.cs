using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternLib
{
    public abstract class LanguageFactory
    {
        public abstract List<Tuple<Enums.Component, double, double, string, double, double>> Components { get; set; }
        public abstract void Compile();
        public abstract void Display();
        public abstract void CreateComponent();
    }
}
